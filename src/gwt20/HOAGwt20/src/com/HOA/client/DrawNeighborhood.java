package com.HOA.client;

import com.claudiushauptmann.gwt.multipage.client.MultipageEntryPoint;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.core.client.JsArray;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.maps.client.MapUIOptions;
import com.google.gwt.maps.client.MapWidget;
import com.google.gwt.maps.client.event.PolygonCancelLineHandler;
import com.google.gwt.maps.client.event.PolygonEndLineHandler;
import com.google.gwt.maps.client.event.PolygonLineUpdatedHandler;
import com.google.gwt.maps.client.geocode.Geocoder;
import com.google.gwt.maps.client.geocode.LocationCallback;
import com.google.gwt.maps.client.geocode.Placemark;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.maps.client.overlay.Marker;
import com.google.gwt.maps.client.overlay.MarkerOptions;
import com.google.gwt.maps.client.overlay.PolyEditingOptions;
import com.google.gwt.maps.client.overlay.PolyStyleOptions;
import com.google.gwt.maps.client.overlay.Polygon;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.TextBox;

//@MultipageEntryPoint(urlPattern = "/Neighborhood/Create|/Neighborhood/Edit/[\\\\w\\\\W]*")
@MultipageEntryPoint(urlPattern = "Neighborhood/Create.*|Neighborhood/Edit/[\\\\w\\\\W]*.*")
public class DrawNeighborhood implements EntryPoint {

	private Label message2 = new Label();
	private Polygon lastPolygon;
	private MapWidget map;
	private Button editbtn = Util.CreateButton("Edit Neighborhood");
	Button drawbtn = Util.CreateButton("Draw Neighborhood");
	Button savebtn = Util.CreateButton("Save Neighborhood");
	Button startOverbtn = Util.CreateButton("Start Over");
	@Override
	public void onModuleLoad() {
		RootPanel panel = RootPanel.get("map");
		
		if (panel == null){
			Window.alert("no panel");
			return ;
		}
		
		LatLng latLng = LatLng.fromUrlValue("30.826780904779774,-85.517578125");
		map = new MapWidget(latLng, 9);
		//map.addOverlay(new Marker(latLng));
		map.setSize("600px", "500px");
		
		
		panel.add(new Label("Search by address :"));
		final TextBox searchBox = new TextBox();
		panel.add(searchBox);
		Button searchBtn = new Button("Search");
		panel.add(searchBtn);
		searchBtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				//ThisIsAJavascriptmethod();
				Geocoder geocoder = new Geocoder();
				geocoder.getLocations(searchBox.getValue(), new LocationCallback() {
					
					@Override
					public void onSuccess(JsArray<Placemark> locations) {
						if (locations.length() ==0){
							Window.alert("No results found for " + searchBox.getText());
						} else {
							map.setCenter(locations.get(0).getPoint());
							MarkerOptions options = MarkerOptions.newInstance();
							options.setTitle(locations.get(0).getAddress());
							Marker marker = new Marker(locations.get(0).getPoint(),options);
							map.addOverlay(marker);
							map.setZoomLevel(16);
							
						}
						
					}
					
					@Override
					public void onFailure(int statusCode) {
						Window.alert("No results found for " + searchBox.getText());
					}
				});
			}
		});
		
		
		

	    // Change the default UI controls a bit to help with drawing.
	    MapUIOptions options = map.getDefaultUI();
	    options.setScrollwheel(false);
	    options.setDoubleClick(false);
	    options.setLargeMapControl3d(true);
	    map.setUI(options);
	    map.setDoubleClickZoom(false);
	   // map.setDraggable(false);
		
		panel.add(map);
		
		panel.add(message2);
		
		Boolean edit = TryLoadExistingPolygon();
		
		if (!edit){
			drawbtn.addClickHandler(new ClickHandler() {
				
				@Override
				public void onClick(ClickEvent event) {
					drawbtn.setVisible(false);
					createPolygon(null);
					
				}
			});
			panel.add(drawbtn);
			
			

		}
		editbtn.setVisible(false);
		editbtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				editbtn.setVisible(false);
				startOverbtn.setVisible(true);
				editPolygon();
				
			}
		});
		panel.add(editbtn);
		
		startOverbtn.setVisible(edit);
		startOverbtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				lastPolygon.setEditingEnabled(false);
				lastPolygon.setVisible(false);
				createPolygon(null);
				editbtn.setVisible(false);
				savebtn.setVisible(false);
				//startOverbtn.setVisible(false);
			}
		});
		panel.add(startOverbtn);
		
		savebtn.setVisible(edit);
		savebtn.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				Geocoder geocoder = new Geocoder();
				geocoder.getLocations(lastPolygon.getVertex(0), new LocationCallback() {
					
					@Override
					public void onSuccess(JsArray<Placemark> locations) {
						Placemark location = locations.get(0);
						Util.SetHiddenValue("KML", Util.PolygonToString(lastPolygon));
						Util.SetHiddenValue("Location", location.getCity() + " " + location.getState() + " " + location.getPostalCode());
						Util.submitForm();
						
					}
					
					@Override
					public void onFailure(int statusCode) {
						Window.alert("Error geocoding from google:" + statusCode);
						
					}
				});
				
			}
		});
		panel.add(savebtn);
	}
	
	private void cancelEdit() {
	    if (lastPolygon == null) {
	      return;
	    }
	    // allow up to 10 vertices to exist in the polygon.
	    lastPolygon.setEditingEnabled(false);
	    this.message2.setText(Util.PolygonToString(lastPolygon));
	  }
	
	
	
	private void editPolygon() {
	    if (lastPolygon == null) {
	      return;
	    }
	    // allow up to 10 vertices to exist in the polygon.
	    lastPolygon.setEditingEnabled(PolyEditingOptions.newInstance(10));
	  }
	private Boolean TryLoadExistingPolygon(){
		String kml = Util.GetHiddenValue("KML");
		if (kml != "" && kml.length() != 0){ //some weird thing here in debug mode
			createPolygon(Util.StringToPolygon(kml));
			map.setCenter(lastPolygon.getBounds().getCenter(),  map.getBoundsZoomLevel(lastPolygon.getBounds()));
			return true;
		}
		return false;
	}
	private void createPolygon(Polygon polygon) {
		startOverbtn.setVisible(true);
		PolyStyleOptions style = PolyStyleOptions.newInstance("#FF0000", 3,
	        0.7);

//	    final Polygon poly = new Polygon(new LatLng[0], "#FF0000", 3, 0.7,
//	    		"#FF0000", true ? .7 : 0.0);
//	    
//	    
		Boolean edit = true;
		if (polygon == null){
			polygon = new Polygon(new LatLng[0]);
			edit=false;
		}
		
		final Polygon poly =polygon;
		
		
		
		
	    lastPolygon = poly;
	    map.addOverlay(poly);
	    if (!edit) {
	    	poly.setDrawingEnabled();
	    } else {
	    	poly.setEditingEnabled(true);
	    }
	    poly.setStrokeStyle(style);
	    message2.setText("");
	    poly.addPolygonLineUpdatedHandler(new PolygonLineUpdatedHandler() {

	      public void onUpdate(PolygonLineUpdatedEvent event) {
	        message2.setText(message2.getText() + " : Polygon Updated");
//	        if (poly.getArea()/(1000*1000) > 10 ){
//	    		  Window.alert("Neighborhood can not be larger than 10 square KM");
//	    		  startOverbtn.click();
//	    	  }
	        
	      }
	    });

	  
	    
	    poly.addPolygonCancelLineHandler(new PolygonCancelLineHandler() {

	      public void onCancel(PolygonCancelLineEvent event) {
	        message2.setText(message2.getText() + " : Polygon Cancelled");
	      }
	    });

	    poly.addPolygonEndLineHandler(new PolygonEndLineHandler() {

	      public void onEnd(PolygonEndLineEvent event) {
	    	  editbtn.setVisible(true);
	    	  savebtn.setVisible(true);
	    	  message2.setText(message2.getText() + " : Polygon End at "
	            + event.getLatLng() + ".  Bounds="
	            + poly.getBounds().getNorthEast() + ","
	            + poly.getBounds().getSouthWest() + " area=" + poly.getArea()
	            + "m");
	    	  
	    	  if (poly.getArea()/(1000*1000) > 10 ){
	    		  Window.alert("Neighborhood can not be larger than 10 square KM");
	    		  startOverbtn.click();
	    	  }
	      }
	    });
	    
	   
	  }

}
