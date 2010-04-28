package com.HOA.client.cms;

import com.HOA.client.RichTextToolbar;
import com.claudiushauptmann.gwt.multipage.client.MultipageEntryPoint;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.DecoratedPopupPanel;
import com.google.gwt.user.client.ui.DialogBox;
import com.google.gwt.user.client.ui.Grid;
import com.google.gwt.user.client.ui.HTML;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.Panel;
import com.google.gwt.user.client.ui.PopupPanel;
import com.google.gwt.user.client.ui.RichTextArea;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.VerticalPanel;

@MultipageEntryPoint(urlPattern = ".*")
public class CmsManager implements EntryPoint {

	@Override
	public void onModuleLoad() {
		final CmsEditor editor = new CmsEditor();
		editor.center();
	}

	private native String GetCmsIds()/*-{
		return $wnd.cmsIds;
	}-*/;
	
	
}

