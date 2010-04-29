package com.HOA.client.cms;

import java.util.Map;

import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.event.dom.client.MouseOutEvent;
import com.google.gwt.event.dom.client.MouseOutHandler;
import com.google.gwt.event.dom.client.MouseOverEvent;
import com.google.gwt.event.dom.client.MouseOverHandler;
import com.google.gwt.user.client.Element;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Anchor;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.PopupPanel;
import com.google.gwt.user.client.ui.UIObject;

public class ContentWidget {
	private Label uiElement;
	private PopupPanel popUp;
	private CmsEditor editor;
	public ContentWidget(Element domElement){
		this.uiElement = Label.wrap( domElement);
		this.editor = new CmsEditor(this);
		this.AttachMouseOverToContentArea();
	}
	
	private void AttachMouseOverToContentArea(){
		Label label = new Label();
		label.setText("Edit");
		Anchor editLink = new Anchor();
		editLink.setText("Edit");
		editLink.addClickHandler(new ClickHandler() {
			
			@Override
			public void onClick(ClickEvent event) {
				editor.center();
				
			}
		});
		popUp = new PopupPanel(true);
		popUp.setWidget(editLink);
		uiElement.addMouseOverHandler(new MouseOverHandler() {
				@Override
				public void onMouseOver(MouseOverEvent event) {
					popUp.showRelativeTo((UIObject) event.getSource());
					
				}
			});
		
	}
	public String getHtmlContent() {
		return this.uiElement.getElement().getInnerHTML();
	}
	public void setHtmlContent(String html) {
		this.uiElement.getElement().setInnerHTML(html);
	}
	
	
}
