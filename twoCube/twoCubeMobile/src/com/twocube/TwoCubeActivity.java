package com.twocube;

import java.io.File;
import java.io.IOException;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.json.simple.JSONValue;

import com.nostra13.universalimageloader.cache.disc.impl.UnlimitedDiscCache;
import com.nostra13.universalimageloader.cache.memory.MemoryCacheAware;
import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;
import com.nostra13.universalimageloader.utils.StorageUtils;
import com.twocube.JSONHandler.OnResponseReceivedListener;
import com.twocube.entities.Survey;
import com.twocube.entities.SurveyQuestion;
import com.twocube.entities.SurveyQuestionOption;

import android.app.Activity;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.text.Editable;
import android.text.InputType;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnKeyListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.DatePicker.OnDateChangedListener;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.HorizontalScrollView;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.LayoutParams;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.TextView;
/**
 * 
 * @author Nobody
 * Main activity class
 */
public class TwoCubeActivity extends Activity {
	// JSON handler to handle receiving the information from server and sending response back
	JSONHandler jHandler,jSubmitHandler;
	// Handler to enable other threads to update UI in main thread
	Handler mHandler;
	//String jsonString= "{\"Id\":2,\"surveyTitle\":\"Sample Survey\",\"surveyDescription\":\"A Random Sample Survey. This is just a sample of how json can be used to render a survey.\",\"surveyStatus\":false,\"surveyCreated\":\"\",\"surveyStartDate\":\"\",\"surveyEndDate\":\"\",\"surveyQuestionList\":[{\"Id\":3,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"What is your favourite color?\",\"surveyQuestionOptionList\":[{\"Id\":4,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"White\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":5,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Yellow\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":6,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Blue\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":7,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Green\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":8,\"surveyQuestionOptionType\":2,\"surveyQuestionOptionTitle\":\"Enter another color:\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":11,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Who is the most hardworking person in our team?\",\"surveyQuestionOptionList\":[{\"Id\":12,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":13,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Wei Leng\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":14,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Hong Jing\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":15,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Xu Ai\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":16,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Wesley\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":19,\"surveyQuestionType\":0,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"And the best phone is\",\"surveyQuestionOptionList\":[{\"Id\":20,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S 3\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":21,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S 2\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":22,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy S\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":23,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"HTC One X\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":24,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Galaxy Nexus\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":25,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Motorola Droid Razr Maxx\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":28,\"surveyQuestionType\":1,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Who is the most hardworking person in our team? (You can choose more than 1 answer)\",\"surveyQuestionOptionList\":[{\"Id\":29,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":30,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":31,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":32,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":33,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":34,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":35,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":36,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":37,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"June\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":44,\"surveyQuestionType\":2,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"How hardworking is June?\",\"surveyQuestionOptionList\":[{\"Id\":45,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"Hardworkingness\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":48,\"surveyQuestionType\":3,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"How young is this pretty young star? Numeric input.\",\"surveyQuestionOptionList\":[{\"Id\":49,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/weileng.peh/picture?type=large\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":52,\"surveyQuestionType\":4,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Or the birthday of this talented actor/singer? Date input.\",\"surveyQuestionOptionList\":[{\"Id\":53,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/197371292379/picture?type=large\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null},{\"Id\":56,\"surveyQuestionType\":5,\"surveyQuestionIsCompulsory\":false,\"surveyQuestionTitle\":\"Which picture is the odd one out?\",\"surveyQuestionOptionList\":[{\"Id\":57,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/alexei.sourin/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":58,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/kuiyu.chang/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":59,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/bengkoon.ng/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":60,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/bingsheng.he/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null},{\"Id\":61,\"surveyQuestionOptionType\":0,\"surveyQuestionOptionTitle\":\"http://graph.facebook.com/limws.brandon/picture?type=square\",\"surveyQuestionOptionTitleType\":0,\"surveyQuestionOptionRange\":0,\"surveyQuestionOptionMinText\":null,\"surveyQuestionOptionMaxText\":null}],\"surveyQuestionResponseList\":null}],\"respondentList\":null}";
	String surveyId;
	//Layout inflater to inflate ui created in xml
	LayoutInflater inflater;
	//Survey object
	Survey survey;
	
	//Image loader for universal image loader
	ImageLoader imageLoader;// = ImageLoader.getInstance();
	DisplayImageOptions options;
	File cacheDir;
	/** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        Uri data = getIntent().getData();
        //data.getQueryParameter("s").toString();
        //initialize various classes
        inflater = ((Activity) this).getLayoutInflater();
        jHandler = new JSONHandler();
        jSubmitHandler = new JSONHandler();
        mHandler = new Handler();
        
        imageLoader = ImageLoader.getInstance();
		cacheDir = StorageUtils.getCacheDirectory(this);
		ImageLoaderConfiguration config = new ImageLoaderConfiguration.Builder(getApplicationContext()).defaultDisplayImageOptions(DisplayImageOptions.createSimple()).denyCacheImageMultipleSizesInMemory().offOutOfMemoryHandling().build();
		imageLoader.init(config);
		options = new DisplayImageOptions.Builder().cacheOnDisc().build();
		
		//set response handler for getting survey
        jHandler.setOnResponseReceivedListener(new OnResponseReceivedListener() {
			
			@Override
			public void onResponseReceived(final String receivedString, boolean success) {
				mHandler.post(new Runnable() {
					@Override
					public void run() {
						//method to iterate through jsonstring and generate survey ui
						createSurvey(receivedString);
					}
				});
			}
			
			@Override
			public void onIOException() {
			}
		});
        jSubmitHandler.setOnResponseReceivedListener(new OnResponseReceivedListener() {
			
			@Override
			public void onResponseReceived(String receivedString, boolean success) {
				mHandler.post(new Runnable() {
					
					@Override
					public void run() {
						//exits when successfully created
						System.exit(0);
					}
				});
				
			}
			@Override
			public void onIOException() {
			}
		});
        //name value pairs as it sends via http post
        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
        if(data!=null){
        	nameValuePairs.add(new BasicNameValuePair("Id", data.getQueryParameter("s")==null?"80":data.getQueryParameter("s")));
        	Log.w("jsonhandler", data.getQueryParameter("s"));
        	surveyId = data.getQueryParameter("s");
        }
        else nameValuePairs.add(new BasicNameValuePair("Id", "80"));
        //same web service as that used in web version
        jHandler.handleJSON(nameValuePairs, "http://twocube1.elasticbeanstalk.com/Services/SurveyControllerService.asmx/getSurveyById");
    }
    
    public void createSurvey(String jsonString){
    	try {
    		//create json object from json string. using gson library
			JSONObject jsonobj = new JSONObject(jsonString);
			survey = new Survey();
			//set text for title and description
			TextView tvSurveyTitle =(TextView)findViewById(R.id.tv_title_main);
			TextView tvSurveyDescription =(TextView)findViewById(R.id.tv_description_main);
			tvSurveyTitle.setText(jsonobj.getString("surveyTitle"));
			tvSurveyDescription.setText(jsonobj.getString("surveyDescription"));
			
			JSONArray questionArray = new JSONArray(jsonobj.getString("surveyQuestionList"));
			//iterate through each question
			for (int i = 0; i < questionArray.length(); i++) {
				JSONObject tempQuestion = questionArray.getJSONObject(i);
				//Dynamically create a view for each question
				View v = inflater.inflate(R.layout.question_layout, null); 
				LinearLayout llQuestion = (LinearLayout)v.findViewById(R.id.ll_question);
				((TextView)v.findViewById(R.id.tv_title_question)).setText(tempQuestion.getString("surveyQuestionTitle"));
				
				//using if else instead of switch as switch has been deprecated after android 2.1(i think its 2.1)
				if(tempQuestion.getInt("surveyQuestionType") == 0||tempQuestion.getInt("surveyQuestionType") == 10){//1 and 10 are radio buttons
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					RadioGroup rg = new RadioGroup(this);
					int pos = i;
					final SurveyQuestion sq =  new SurveyQuestion(0);
					survey.getQuestionList().add(sq);
					final List<RadioButton> rbList = new ArrayList<RadioButton>();
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						final RadioButton rb = new RadioButton(this);
						rbList.add(rb);
						
						if(tempOption.getInt("surveyQuestionOptionTitleType")==2){//2 means image
							LinearLayout hllOption = new LinearLayout(this);
							hllOption.setOrientation(LinearLayout.HORIZONTAL);
							ImageView ivImage;
							ivImage = new ImageView(this);
							ivImage.setLayoutParams(new LinearLayout.LayoutParams(120, 120));
							hllOption.addView(rb);
							hllOption.addView(ivImage);
							imageLoader.displayImage(tempOption.getString("surveyQuestionOptionTitle"), ivImage,new DisplayImageOptions.Builder().cacheOnDisc().build());
							//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							rg.addView(hllOption);
							int q =j;
							rb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
								
								@Override
								public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
									int i=0;
									for(RadioButton rbTemp:rbList)
									{
										if(!rbTemp.equals(rb)) rbTemp.setChecked(false);
										else sq.setNumAns(i);
										i++;
									}
									
								}
							});
						}else {
							rb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							rg.addView(rb);
						}
						//CheckBox cb = new CheckBox(this);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
					}
					rg.setOnCheckedChangeListener(new OnCheckedChangeListener() {
						@Override
						public void onCheckedChanged(RadioGroup group, int checkedId) {
							if(checkedId == -1){}
							else sq.setNumAns(group.indexOfChild(findViewById(group.getCheckedRadioButtonId())));
						}
					});
					llQuestion.addView(rg);
				}else if(tempQuestion.getInt("surveyQuestionType") == 1){//check boxes
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					final SurveyQuestion sq =  new SurveyQuestion(1);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						CheckBox cb = new CheckBox(this);
						if(tempOption.getInt("surveyQuestionOptionTitleType")==2){//image
							LinearLayout hllOption = new LinearLayout(this);
							hllOption.setOrientation(LinearLayout.HORIZONTAL);
							ImageView ivImage;
							ivImage = new ImageView(this);
							ivImage.setLayoutParams(new LinearLayout.LayoutParams(120, 120));
							
							hllOption.addView(cb);
							hllOption.addView(ivImage);
							imageLoader.displayImage(tempOption.getString("surveyQuestionOptionTitle"), ivImage,new DisplayImageOptions.Builder().cacheOnDisc().build());
							//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							llQuestion.addView(hllOption);
						}else{
							//CheckBox cb = new CheckBox(this);
							cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							llQuestion.addView(cb);
						}
						final int loc = j;
						sq.getOptionList().add(new SurveyQuestionOption(0));
						cb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
							
							@Override
							public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
								int a = 0 ;
								if(isChecked) a=1;
								sq.getOptionList().get(loc).setNumAns(a);
								
							}
						});
						
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 2){//slider
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					final SurveyQuestion sq =  new SurveyQuestion(2);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						SeekBar sb = new SeekBar(this);
						sb.setMax(100);
						sb.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {
							
							@Override
							public void onStopTrackingTouch(SeekBar seekBar) {
								// TODO Auto-generated method stub
								
							}
							
							@Override
							public void onStartTrackingTouch(SeekBar seekBar) {
								// TODO Auto-generated method stub
								
							}
							
							@Override
							public void onProgressChanged(SeekBar seekBar, int progress,
									boolean fromUser) {
								sq.setNumAns(progress);
								
							}
						});
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(sb);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 3){//numerical
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					final SurveyQuestion sq =  new SurveyQuestion(3);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						final EditText et = new EditText(this);
						et.setInputType(InputType.TYPE_CLASS_NUMBER);
						et.addTextChangedListener(new TextWatcher() {
							
							@Override
							public void onTextChanged(CharSequence s, int start, int before, int count) {
								sq.setStrAns(et.getEditableText().toString());
								Log.w("JSON", et.getEditableText().toString());
								
							}
							
							@Override
							public void beforeTextChanged(CharSequence s, int start, int count,
									int after) {
								// TODO Auto-generated method stub
								
							}
							
							@Override
							public void afterTextChanged(Editable s) {
								// TODO Auto-generated method stub
								
							}
						});
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(et);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 4){//date
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					final SurveyQuestion sq =  new SurveyQuestion(4);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						final DatePicker dp = new DatePicker(this);
						final Calendar c = Calendar.getInstance();
						dp.init(c.get(Calendar.YEAR), c.get(Calendar.MONTH), c.get(Calendar.DAY_OF_MONTH), new OnDateChangedListener() {
							
							@Override
							public void onDateChanged(DatePicker view, int year, int monthOfYear,
									int dayOfMonth) {
								sq.setStrAns(Integer.toString(monthOfYear+1)+"/"+Integer.toString(dayOfMonth)+"/"+Integer.toString(year));
								
							}
						});
						//et.setInputType(InputType.TYPE_DATETIME_VARIATION_DATE);
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						dp.setOnClickListener(new OnClickListener() {
							
							@Override
							public void onClick(View v) {
								sq.setStrAns(Integer.toString(dp.getMonth()+1)+"/"+Integer.toString(dp.getDayOfMonth())+"/"+Integer.toString(dp.getYear()));
								Log.w("dp", Integer.toString(dp.getMonth()+1)+"/"+Integer.toString(dp.getDayOfMonth())+"/"+Integer.toString(dp.getYear()));
							}
						});
						llQuestion.addView(dp);
					}
				}else if(tempQuestion.getInt("surveyQuestionType") == 6||tempQuestion.getInt("surveyQuestionType") == 7){//text
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					final SurveyQuestion sq =  new SurveyQuestion(3);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						final EditText et = new EditText(this);
						//et.setInputType(InputType.TYPE_CLASS_NUMBER);
						et.addTextChangedListener(new TextWatcher() {
							
							@Override
							public void onTextChanged(CharSequence s, int start, int before, int count) {
								sq.setStrAns(et.getEditableText().toString());
								Log.w("JSON", et.getEditableText().toString());
								
							}
							
							@Override
							public void beforeTextChanged(CharSequence s, int start, int count,
									int after) {
								// TODO Auto-generated method stub
								
							}
							
							@Override
							public void afterTextChanged(Editable s) {
								// TODO Auto-generated method stub
								
							}
						});
						//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						llQuestion.addView(et);
					}
				}if(tempQuestion.getInt("surveyQuestionType") == 5){//horizontal radio button
					JSONArray optionArray = new JSONArray(tempQuestion.getString("surveyQuestionOptionList"));
					RadioGroup rg = new RadioGroup(this);
					rg.setOrientation(RadioGroup.HORIZONTAL);
					HorizontalScrollView hsv = new HorizontalScrollView(this);
					hsv.addView(rg);
					final List<RadioButton> rbList = new ArrayList<RadioButton>();
					//rg.setLayoutParams(LayoutParams.);
					int pos = i;
					final SurveyQuestion sq =  new SurveyQuestion(0);
					survey.getQuestionList().add(sq);
					for (int j = 0; j < optionArray.length(); j++) {
						JSONObject tempOption = optionArray.getJSONObject(j);
						final RadioButton rb = new RadioButton(this);
						rbList.add(rb);
						if(tempOption.getInt("surveyQuestionOptionTitleType")==2){
							
							LinearLayout hllOption = new LinearLayout(this);
							hllOption.setOrientation(LinearLayout.VERTICAL);
							ImageView ivImage;
							ivImage = new ImageView(this);
							ivImage.setLayoutParams(new LinearLayout.LayoutParams(120, 120));
							hllOption.addView(ivImage);
							hllOption.addView(rb);
							
							imageLoader.displayImage(tempOption.getString("surveyQuestionOptionTitle"), ivImage,new DisplayImageOptions.Builder().cacheOnDisc().build());
							//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							rg.addView(hllOption);
						}else{
							
							LinearLayout hllOption = new LinearLayout(this);
							hllOption.setOrientation(LinearLayout.VERTICAL);
							TextView tv = new TextView(this);
							tv.setText(tempOption.getString("surveyQuestionOptionTitle"));
							hllOption.addView(tv);
							hllOption.addView(rb);
							
							//rb.setText(tempOption.getString("surveyQuestionOptionTitle"));
							//rb.setBackgroundColor(Color.BLUE);
							rg.addView(hllOption);
							//CheckBox cb = new CheckBox(this);
							//cb.setText(tempOption.getString("surveyQuestionOptionTitle"));
						}
						rb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
							
							@Override
							public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
								int i=0;
								for(RadioButton rbTemp:rbList)
								{
									if(!rbTemp.equals(rb)) rbTemp.setChecked(false);
									else sq.setNumAns(i);
									i++;
								}
								
							}
						});
						
					}
					rg.setOnCheckedChangeListener(new OnCheckedChangeListener() {
						
						@Override
						public void onCheckedChanged(RadioGroup group, int checkedId) {
							if(checkedId == -1){}
							else sq.setNumAns(group.indexOfChild(findViewById(group.getCheckedRadioButtonId())));
							
						}
					});
					//if(tempOption.getInt("surveyQuestionOptionTitleType")==2)
					llQuestion.addView(hsv);
				}
				
				((LinearLayout)findViewById(R.id.ll_main)).addView(v);
				
			}
			Button bnSubmit = new Button(this);
			bnSubmit.setText("Submit");
			
			bnSubmit.setOnClickListener(new OnClickListener() {
				
				@Override
				public void onClick(View v) {
					Map main=new LinkedHashMap();
					Map obj=new LinkedHashMap();
					int i = 0;
					for(SurveyQuestion question:survey.getQuestionList()){
						if(question.getQuestionType()==0)
							obj.put(Integer.toString(i), question.getNumAns());
						else if(question.getQuestionType()==2)
							obj.put(Integer.toString(i), question.getNumAns());
						else if(question.getQuestionType()==1) {
							LinkedList list = new LinkedList();
							int m = 0;
							for(SurveyQuestionOption q:question.getOptionList())
							{
								if(q.getNumAns()==1)
									list.add(new Integer(m));
								m++;
							}
							obj.put(Integer.toString(i), list);
						}
						else if(question.getQuestionType()==3)
							obj.put(Integer.toString(i), question.getStrAns());
						else if (question.getQuestionType()==4)
							obj.put(Integer.toString(i), question.getStrAns());
						else if(question.getQuestionType()==5)
							obj.put(Integer.toString(i), question.getNumAns());
						i++;
					}
					main.put("s", obj);
					main.put("surveyId",surveyId);
					main.put("surveyBrowserBrowser","Mobile App");
					main.put("surveyBrowserVersion","1");
					main.put("surveyBrowserOS","Android");
					main.put("surveyLocaleLang","en");
					main.put("surveyLocaleCountry","us");
					main.put("surveyLocationCountryCode","SG");
					main.put("surveyTime","34543");
					StringWriter out = new StringWriter();
					   try {
						JSONValue.writeJSONString(main, out);
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					   String jsonText = out.toString();
					   Log.w("JSON", jsonText);
					   List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
					   nameValuePairs.add(new BasicNameValuePair("jsonString", jsonText));
					   jSubmitHandler.handleJSON(nameValuePairs, "http://twocube1.elasticbeanstalk.com/Services/SurveyControllerService.asmx/submitSurvey");
				}
			});
			((LinearLayout)findViewById(R.id.ll_main)).addView(bnSubmit);
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    }
}