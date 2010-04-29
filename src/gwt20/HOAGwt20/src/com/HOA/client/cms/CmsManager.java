package com.HOA.client.cms;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import com.HOA.client.RichTextToolbar;
import com.HOA.client.utilities.StringUtil;
import com.claudiushauptmann.gwt.multipage.client.MultipageEntryPoint;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.dom.client.DivElement;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.event.dom.client.MouseOverEvent;
import com.google.gwt.event.dom.client.MouseOverHandler;
import com.google.gwt.user.client.DOM;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.DecoratedPopupPanel;
import com.google.gwt.user.client.ui.DialogBox;
import com.google.gwt.user.client.ui.FocusPanel;
import com.google.gwt.user.client.ui.Grid;
import com.google.gwt.user.client.ui.HTML;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.Panel;
import com.google.gwt.user.client.ui.PopupPanel;
import com.google.gwt.user.client.ui.RichTextArea;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.UIObject;
import com.google.gwt.user.client.ui.VerticalPanel;

@MultipageEntryPoint(urlPattern = ".*")
public class CmsManager implements EntryPoint {

	private HashMap<String,ContentWidget> ContentAreas = new HashMap<String, ContentWidget>();
	
	@Override
	public void onModuleLoad() {
		
		ArrayList<String> ids = GetArrayCmsIds();
		if (AttachContentWidgets(GetArrayCmsIds()))
		{
		
		}
		
		
//		final CmsEditor editor = new CmsEditor();
//		editor.center();
	}
	
	private Boolean AttachContentWidgets(ArrayList<String> ids) {
		for (String id:ids){
			DOM.getElementById(id);
			ContentAreas.put(id, new ContentWidget(DOM.getElementById(id)));
		}
		return ids.size() > 0;
	}
	
	

	private static ArrayList<String> GetArrayCmsIds() {
		return StringUtil.SplitToArrayList(GetCmsIds());
	}
	
	private static native String GetCmsIds()/*-{
		return $wnd.cmsIds;
	}-*/;
	
	
}

