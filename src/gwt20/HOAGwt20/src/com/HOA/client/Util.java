package com.HOA.client;

import com.google.gwt.dom.client.Document;
import com.google.gwt.dom.client.FormElement;
import com.google.gwt.dom.client.InputElement;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.maps.client.overlay.Polygon;
import com.google.gwt.user.client.DOM;
import com.google.gwt.user.client.Event;
import com.google.gwt.user.client.ui.Button;

public class Util {
	static void SetHiddenValue(String name, String value){
		((InputElement)DOM.getElementById(name).cast()).setValue(value);
	}
	static String GetHiddenValue(String name){
		return ((InputElement)DOM.getElementById(name).cast()).getValue();
	}
	static String PolygonToString(Polygon polygon){
		//String[] points = new String[polygon.getVertexCount()];
		String pointString = "POLYGON((";
		String seperator = "";
		for (int i = 0; i < polygon.getVertexCount(); i++) {
			pointString += seperator + polygon.getVertex(i).getLongitude()+ " " + polygon.getVertex(i).getLatitude();
			seperator = ",";
		}
		pointString += "))";
		return pointString;
	}
	static Button CreateButton(String text){
		 Button b = new Button(text){ 
             public void onBrowserEvent(Event event) { 
                 if (DOM.eventGetType(event) == Event.ONCLICK) { 
                         DOM.eventPreventDefault(event); 
                         DOM.eventCancelBubble(event, true); 
                 } 
                 super.onBrowserEvent(event); 
         } 
		 	}; 
    
		 //DOM.setElementAttribute(b.getElement(), "type", "button");
		 return b;
	}
	static Polygon StringToPolygon(String polyString){
		polyString = polyString.replaceAll("POLYGON", "");
		polyString = polyString.replaceAll("\\(\\(", "");
		polyString = polyString.replaceAll("\\)\\)", "");
		
		String[] pointStrings = polyString.split(",");
		LatLng[] points = new LatLng[pointStrings.length];
		int index = 0;
		for (String pointString : pointStrings) {
			String[] latlongs = pointString.split(" ");
			points[index]= LatLng.newInstance(new Double(latlongs[1]), new Double(latlongs[0]));
			index++;
		}
		return new Polygon(points);
		
	}
	public static void submitForm() {
		((FormElement)Document.get().getElementsByTagName("form").getItem(0).cast()).submit();
	}
}
