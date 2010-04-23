package com.hoagwt.client;

import com.claudiushauptmann.gwt.multipage.client.MultipageEntryPoint;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.maps.client.MapWidget;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.maps.client.overlay.Marker;
import com.google.gwt.user.client.ui.RootPanel;

@MultipageEntryPoint(urlPattern = "/UserHome/Details/[\\\\w\\\\W]*")
public class MapHomeDisplay implements EntryPoint {

	@Override
	public void onModuleLoad() {
		RootPanel panel = RootPanel.get("MapDisplay");
		LatLng latLng = LatLng.fromUrlValue(panel.getElement().getAttribute("coordinates"));
		final MapWidget map = new MapWidget(latLng, 17);
		map.addOverlay(new Marker(latLng));
		map.setSize("500px", "300px");
		panel.add(map);

	}
	
//	GeoXmlOverlay.load("http://maps.google.com/maps/ms?ie=UTF8&hl=en&vps=1&jsv=190a&msa=0&output=nl&msid=106979245903453176749.0004779109f86bbabd62d",
//			new GeoXmlLoadCallback(){
//
//		@Override
//		public void onFailure(String url, Throwable caught) {
//			Window.alert(caught.toString());
//			
//		}
//
//		@Override
//		public void onSuccess(String url, GeoXmlOverlay overlay) {
//			map.addOverlay(overlay);
//			
//		}});

}
