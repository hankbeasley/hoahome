package com.hoagwt.client;

import com.google.gwt.core.client.JsArray;
import com.google.gwt.junit.client.GWTTestCase;
import com.google.gwt.maps.client.geocode.LocationCallback;
import com.google.gwt.maps.client.geocode.Placemark;

/**
 * GWT JUnit tests must extend GWTTestCase.
 */
public class searchableMapTest extends GWTTestCase {

  /**
   * Must refer to a valid module that sources this class.
   */
  public String getModuleName() {
    return "com.hoagwt.HOAGwtProject";
  }

  /**
   * Add as many tests as you like.
   */
  public void testAddressSearch() {
    SearchableMap searchableMap = new SearchableMap();
    
    searchableMap.Search("11111 Ashcott Dr", new LocationCallback() {
		
		@Override
		public void onSuccess(JsArray<Placemark> locations) {
			assert(locations.length() == 1);
			finishTest();
			
		}
		
		@Override
		public void onFailure(int statusCode) {
		}
	});
    delayTestFinish(2500);
  }

}
