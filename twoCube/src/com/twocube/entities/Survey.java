package com.twocube.entities;

import java.util.ArrayList;
import java.util.List;

public class Survey {
	private List<SurveyQuestion> questionList;

	public Survey(){
		this.questionList = new ArrayList<SurveyQuestion>();
	}
	public Survey(List<SurveyQuestion> questionList) {
		this.questionList = questionList;
	}

	public List<SurveyQuestion> getQuestionList() {
		return questionList;
	}

	public void setQuestionList(List<SurveyQuestion> questionList) {
		this.questionList = questionList;
	}
	
}
