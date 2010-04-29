package com.HOA.client.utilities;

import java.util.ArrayList;

public class StringUtil {
	public static ArrayList<String> SplitToArrayList(String commaList) {
		ArrayList<String> ids = new ArrayList<String>();
		if (commaList == null){
			return ids;
		}
		for (String id : commaList.split(","))
		{
			ids.add(id);
		}
		return ids;
		
	}
}
