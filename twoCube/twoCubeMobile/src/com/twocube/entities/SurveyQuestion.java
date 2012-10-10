package com.twocube.entities;

import java.util.ArrayList;
import java.util.List;

public class SurveyQuestion {
	int questionType;
	int numAns;
	String strAns;
	public int getNumAns() {
		return numAns;
	}
	public void setNumAns(int numAns) {
		this.numAns = numAns;
	}
	public String getStrAns() {
		return strAns;
	}
	public void setStrAns(String strAns) {
		this.strAns = strAns;
	}
	List<SurveyQuestionOption> optionList;
	public SurveyQuestion(int questionType){
		optionList = new ArrayList<SurveyQuestionOption>();
		this.questionType = questionType;
	}
	public List<SurveyQuestionOption> getOptionList() {
		return optionList;
	}
	public void setOptionList(List<SurveyQuestionOption> optionList) {
		this.optionList = optionList;
	}
	public int getQuestionType() {
		return questionType;
	}
	public void setQuestionType(int questionType) {
		this.questionType = questionType;
	}
	
}
