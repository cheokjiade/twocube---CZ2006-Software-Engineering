package com.twocube;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.twocube.entities.Survey;

import android.app.Activity;
import android.os.Bundle;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.SeekBar;
import android.widget.TextView;

public class TwoCubeActivity extends Activity {
	
	String jsonString= "{\"Id\":2,\"surveyTitle\":\"Sample Survey\",\"surveyDescription\":\"A Random Sample Survey. This is just a sample of how json can be used to render a survey.\",\"surveyStatus\":false,\"surveyCreated\":\"\",\"surveyStartDate\":\"\",\"surveyEndDate\":\"\",\"surveyQuestionList\":[{\"Id\":3,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"What is your favourite color?\",\"surveyQuestionOptionList\":[{\"Id\":4,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"White\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":5,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Yellow\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":6,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Blue\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":7,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Green\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":8,\"surveyQuestionOptionType\":2,\"surveyQuestionOptionTitle\":\"Enter another color:\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":11,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Who is the most hardworking person in our team?\",\"surveyQuestionOptionList\":[{\"Id\":12,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":13,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Wei Leng\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":14,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Hong Jing\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":15,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Xu Ai\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":16,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Wesley\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":19,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"And the best phone is\",\"surveyQuestionOptionList\":[{\"Id\":20,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S 3\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":21,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S 2\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":22,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":23,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"HTC One X\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":24,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy Nexus\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":25,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Motorola Droid Razr Maxx\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":28,\"surveyQuestionType\":1,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Who is the most hardworking person in our team? (You can choose more than 1 answer)\",\"surveyQuestionOptionList\":[{\"Id\":29,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":30,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":31,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":32,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":33,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":34,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":35,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":36,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":37,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":44,\"surveyQuestionType\":2,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"How hardworking is June?\",\"surveyQuestionOptionList\":[{\"Id\":45,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Hardworkingness\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":48,\"surveyQuestionType\":3,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"How young is this pretty young star? Numeric input.\",\"surveyQuestionOptionList\":[{\"Id\":49,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/weileng.peh/picture?type=large\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":52,\"surveyQuestionType\":4,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Or the birthday of this talented actor/singer? Date input.\",\"surveyQuestionOptionList\":[{\"Id\":53,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/197371292379/picture?type=large\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":56,\"surveyQuestionType\":5,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Which picture is the odd one out?\",\"surveyQuestionOptionList\":[{\"Id\":57,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/alexei.sourin/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":58,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/kuiyu.chang/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":59,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/bengkoon.ng/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":60,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/bingsheng.he/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":61,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/limws.brandon/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null}],\"respondentList\":null}";
	LayoutInflater inflater;
	Survey survey;
	/** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        inflater = ((Activity) this).getLayoutInflater();
        createSurvey(jsonString);
    }
    
    public void createSurvey(String jsonString){
    	try {
			JSONObject jsonobj = new JSONObject(jsonString);
			survey = new Survey();
			TextView tvSurveyTitle =(TextView)findViewById(R.id.tv_title_main);
			TextView tvSurveyDescription =(TextView)findViewById(R.id.tv_description_main);
			tvSurveyTitle.setText(jsonobj.getString("surveyTitle"));
			tvSurveyDescription.setText(jsonobj.getString("surveyDescription"));
			JSONArray questionArray = new JSONArray(jsonobj.getString("surveyQuestionList"));
			for (int i = 0; i < questionArray.length(); i++) {
				JSONObject tempQuestion = questionArray.getJSONObject(i);
				View v = inflater.inflate(R.layout.question_layout, null); 
				LinearLayout llQuestion = (LinearLayout)v.findViewById(R.id.ll_question);
				((TextView)v.findViewById(R.id.tv_title_question)).setText(tempQuestion.getString("surveyQuestionTitle"));
				
				if(tempQuestion.getInt("surveyQuestionType") == 0){
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					RadioGroup rg = new RadioGroup(this);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						RadioButton rb = new RadioButton(this);
						rb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						rg.addView(rb);
						//CheckBox cb = new CheckBox(this);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						
					}
					llQuestion.addView(rg);
				}else if(tempQuestion.getInt("surveyQuestionType") == 1){
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						CheckBox cb = new CheckBox(this);
						cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(cb);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 2){
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						SeekBar sb = new SeekBar(this);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(sb);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 3){
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						EditText et = new EditText(this);
						et.setInputType(InputType.TYPE_CLASS_NUMBER);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(et);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 4){
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						DatePicker dp = new DatePicker(this);
						//et.setInputType(InputType.TYPE_DATETIME_VARIATION_DATE);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(dp);
					}
				}
				
				((LinearLayout)findViewById(R.id.ll_main)).addView(v);
				
			}
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    }
}