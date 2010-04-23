package com.hoagwt.client;

import com.claudiushauptmann.gwt.multipage.client.MultipageEntryPoint;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.core.client.JsArray;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.maps.client.geocode.Geocoder;
import com.google.gwt.maps.client.geocode.LocationCallback;
import com.google.gwt.maps.client.geocode.Placemark;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.user.client.Command;
import com.google.gwt.user.client.DeferredCommand;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.DialogBox;
import com.google.gwt.user.client.ui.Grid;
import com.google.gwt.user.client.ui.Image;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.SimplePanel;
import com.google.gwt.user.client.ui.TextBox;
import com.google.gwt.user.client.ui.UIObject;
import com.google.gwt.user.client.ui.VerticalPanel;

/**
 * Entry point classes define <code>onModuleLoad()</code>.
 */
@MultipageEntryPoint(urlPattern = "/UserHome/CreateChildByAddress")
//@MultipageEntryPoint(urlPattern = "/")
public class HOAGwtProject implements EntryPoint {
	
	private RootPanel panel;
	public void onModuleLoad() {
		panel = RootPanel.get("map");
		final TextBox textBox = new TextBox();
		
		Button searchBtn = new Button("Search");
	
		panel.add(textBox);
		panel.add(searchBtn);
		final Grid grid = new Grid(0,0);
		panel.add(grid);
		searchBtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				Geocoder geocoder = new Geocoder();
				geocoder.getLocations(textBox.getValue(), new LocationCallback() {
					
					@Override
					public void onSuccess(JsArray<Placemark> locations) {
						grid.resize(locations.length(), 3);
						String mapUrl = "http://maps.google.com/maps/api/staticmap?size=100x100&zoom=17&sensor=false&key=ABQIAAAACPMbozlNv9AIzNvsWUm6vhSvnLMDprvOSMH9Qt_oH5Ww7FTw1hRHT7gTSie1yM34rowNwVfw424XPA&center=";
						for(int i=0;i<locations.length();i++){
							Button addBtn = new Button("Add");
							addBtn.addClickHandler(new AddHomeClickHandler(locations.get(i)));
							
							grid.setWidget(i, 0,addBtn);
							grid.setWidget(i, 1, new Label(locations.get(i).getAddress()));
							Image image = new Image();
							image.setUrl(mapUrl + GetPoint(locations.get(i).getPoint()) + "&" + GetLocationMarker(locations.get(i).getPoint()) );
							grid.setWidget(i, 2, image);
							
							//Window.alert(locations.get(i).getAddress() +locations.get(i).getPostalCode() );
						}
						
					}
					
					@Override
					public void onFailure(int statusCode) {
						// TODO Auto-generated method stub
						
					}
				});
				
			}
		});
		

	}
	
	private class AddHomeClickHandler implements ClickHandler{
		private Placemark placeMark;
		public AddHomeClickHandler(Placemark placeMark){
			this.placeMark = placeMark;
			}
		@Override
		public void onClick(ClickEvent event) {
			DialogBox createPopUpForName = CreatePopUpForName(placeMark.getAddress(), placeMark.getPoint());
			//createPopUpForName.setPopupPosition(event.getNativeEvent().getClientX(), event.getNativeEvent().getClientX());
			createPopUpForName.showRelativeTo((UIObject)event.getSource());

		}
	}
	
	private DialogBox CreatePopUpForName(final String address, final LatLng point){
		final SimplePanel simplePanel = new SimplePanel();
		simplePanel.addStyleName("darkenBackground");
		panel.add(simplePanel);

		
		
		final DialogBox dialogBox = new DialogBox();
		VerticalPanel flowPanel = new VerticalPanel();
		//flowPanel.add(new Label("Specify a name for this location:"));
		final TextBox textBox = new TextBox();
		textBox.setValue("my house");
//		textBox.setFocus(true);
//		textBox.selectAll();
		flowPanel.add(textBox);
		Button saveBtn = new Button("Save");
		flowPanel.add(saveBtn);
		Button cancelBtn = new Button("Cancel");
		flowPanel.add(cancelBtn);
		dialogBox.setWidget(flowPanel);
		dialogBox.setAnimationEnabled(true);
		dialogBox.setText("Name your home");
		dialogBox.setModal(true);
		saveBtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				Util.SetHiddenValue("Name", textBox.getValue());
				Util.SetHiddenValue("Latitude", String.valueOf(point.getLatitude()));
				Util.SetHiddenValue("Longitude", String.valueOf(point.getLongitude()));
				Util.SetHiddenValue("addressFull", address);
				dialogBox.hide();
				
				DeferredCommand.addCommand(new Command() {
					
					@Override
					public void execute() {
						Util.submitForm();
						
					}
				});
				
			}
		});
		
		cancelBtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				
				simplePanel.removeFromParent();
				dialogBox.hide();
			}
		});
		
		return dialogBox;
	}
	
	
	private static String GetPoint(LatLng point){
		return point.getLatitude() + "," + point.getLongitude();
	}
	private static String GetLocationMarker(LatLng point) {
		return "markers=label:my|" + GetPoint(point);
	}
}
