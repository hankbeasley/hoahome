package com.HOA.client.cms;


import com.HOA.client.RichTextToolbar;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.http.client.Request;
import com.google.gwt.http.client.RequestBuilder;
import com.google.gwt.http.client.RequestCallback;
import com.google.gwt.http.client.RequestException;
import com.google.gwt.http.client.Response;
import com.google.gwt.http.client.RequestBuilder.Method;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.DialogBox;
import com.google.gwt.user.client.ui.Grid;
import com.google.gwt.user.client.ui.RichTextArea;
import com.google.gwt.user.client.ui.VerticalPanel;

public class CmsEditor extends DialogBox {
	private RichTextArea area;
	private ContentWidget contentWidget;
	public CmsEditor(ContentWidget contentWidget){
		this.contentWidget = contentWidget;
		
		VerticalPanel dialogVPanel = new VerticalPanel();
		this.setText("Content Administration");
		this.setAnimationEnabled(true);
		
		this.setWidget(dialogVPanel);
		
		dialogVPanel.setHeight("600px");
		
		
		area = new RichTextArea();
	    area.setSize("100%", "14em");
	    area.setHeight("500px");
	    area.setHTML(contentWidget.getHtmlContent());
	    
	    RichTextToolbar toolbar = new RichTextToolbar(area);
	    toolbar.ensureDebugId("cwRichText-toolbar");
	    toolbar.setWidth("100%");
	    
	    // Add the components to a panel
	    Grid grid = new Grid(2, 1);
	    grid.setStyleName("cw-RichText");
	    grid.setWidget(0, 0, toolbar);
	    grid.setWidget(1, 0, area);

	    dialogVPanel.add(grid);
	    
	    final Button closeButton = new Button("Cancel");
		dialogVPanel.add(closeButton);
		
		closeButton.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				hide();
				
			}
		});
		
		final Button saveButton = new Button("Save");
		dialogVPanel.add(saveButton);
		
		saveButton.addClickHandler(new SaveHandler());
		}
		
		private class SaveHandler implements ClickHandler
		{
			@Override
			public void onClick(ClickEvent event) {
				
				
				String url = "http://www.speedhq.com:81/nh/6b696dbe-616c-4421-9011-d080354977b6/Content/Update/49DEE62E-D6C1-4322-BD79-ADB350540AFB";
				RequestBuilder request = new com.google.gwt.http.client.RequestBuilder(RequestBuilder.POST, url);
				request.setHeader("Content-Type", "application/x-www-form-urlencoded"); 
				request.setRequestData("content=" + area.getHTML());
				request.setCallback(new RequestCallback() {
					
					@Override
					public void onResponseReceived(Request request, Response response) {
						contentWidget.setHtmlContent(area.getHTML());
						hide();
					}
					
					@Override
					public void onError(Request request, Throwable exception) {
						Window.alert("Error saving content:" + exception.getMessage());
						
					}
				});
				try {
					request.send();
				} catch (RequestException e) {
					
					e.printStackTrace();
				}
			}
		}
	

}
