package com.HOA.client.utilities.junit;

import java.util.ArrayList;

import com.HOA.client.utilities.StringUtil;



public class StringUtilTest extends junit.framework.TestCase {
	public void testIdsToArrayList() {
		String commaList ="one,two,three";
		ArrayList<String> list = StringUtil.SplitToArrayList(commaList);
		assertEquals(3, list.size());
		assertEquals("two", list.get(1));
	}
	public void testNullSplitsToEmptyArray() {
		ArrayList<String> list = StringUtil.SplitToArrayList(null);
		assertEquals(0, list.size());
		
	}
}
