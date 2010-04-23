package com.hoagwt.client;

import com.google.gwt.core.client.JsArray;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.maps.client.MapWidget;
import com.google.gwt.maps.client.geocode.Geocoder;
import com.google.gwt.maps.client.geocode.LocationCallback;
import com.google.gwt.maps.client.geocode.Placemark;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.FlowPanel;
import com.google.gwt.user.client.ui.Grid;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.TextBox;

public class SearchableMap {
	public MapWidget gMap = new MapWidget();
	public FlowPanel container = new FlowPanel();
	public Grid results = new Grid();
	public TextBox searchBox = new TextBox();
	private Button searchButton = new Button("Search");
	private JsArray<Placemark> locations;
	public SearchableMap() {
		gMap.setSize("500px", "300px");
		container.add(searchBox);
		container.add(searchButton);
		container.add(gMap);
		container.add(results);
		
		searchButton.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				Search(searchBox.getText(), new LocationCallback() {
					
					@Override
					public void onSuccess(JsArray<Placemark> locations) {
						RecieveLocations(locations);
						
					}
					
					@Override
					public void onFailure(int statusCode) {
						
					}
				});
				
			}
		});
	}
	
	private void RecieveLocations(JsArray<Placemark> locations){
		this.locations = locations;
		PopulateTableWithResults(locations);
	}
	
	public void Search(String address, LocationCallback callBack ){
		Geocoder geocoder = new Geocoder();
		geocoder.getLocations(address, callBack);
	}
	
	private void PopulateTableWithResults(JsArray<Placemark> locations){
		results.resize(locations.length(), 3);
		for(int i =0; i< locations.length(); i++){
			this.results.setWidget(i,0, new Label(locations.get(i).getAddress()));
		}
	}
	
}
