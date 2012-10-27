package com.twocube;

import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.util.List;

import org.apache.commons.io.IOUtils;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.HttpConnectionParams;

import android.os.Looper;
import android.util.Log;

public class JSONHandler {
	OnResponseReceivedListener onResponseReceivedListener = null;
	
	public JSONHandler(){
		
	}
	
	public void handleJSON(final List<NameValuePair> nameValuePairs, final String url/*, final int action, final Handler mHandler*/) {
		//pd = ProgressDialog.show(this, "", "Loading. Please wait...", true);
		Thread t = new Thread(){
			@Override
			public void run() {
				Looper.prepare(); //For Preparing Message Pool for the child Thread
				HttpClient client = new DefaultHttpClient();
				HttpConnectionParams.setConnectionTimeout(client.getParams(), 5000); //Timeout Limit
				HttpResponse response;
				try{
					HttpPost post = new HttpPost(url);
					post.setEntity(new UrlEncodedFormEntity(nameValuePairs));
					//Log.w("myapp",post.getEntity().toString());
					response = client.execute(post);
					/*Checking response */
					if(response!=null){
						//String inputLine;
						InputStream in = response.getEntity().getContent(); //Get the data in the entity
						String total = IOUtils.toString(in);
						if(onResponseReceivedListener!=null)
							onResponseReceivedListener.onResponseReceived(total, true);
		            
						Log.w("jsonhandler", total);
					}else{
						Log.w("jsonhandler", "no response");
						if(onResponseReceivedListener!=null)
							onResponseReceivedListener.onResponseReceived("No response", false);
					}

				}
				catch (IllegalArgumentException e){
					e.printStackTrace();
					Log.w("jsonhandler", "IllegalArgumentException");
				}
				catch (UnsupportedEncodingException e) {
					e.printStackTrace();
					Log.w("jsonhandler", "UnsupportedEncodingException");
				}
				catch(ClientProtocolException e){
					Log.w("jsonhandler", "ClientProtocolException");
				}
				catch(IOException e){
					Log.w("jsonhandler", e.getMessage());
					if(onResponseReceivedListener!=null)
						onResponseReceivedListener.onIOException();
				}
				
				catch(Exception e){
					Log.w("jsonhandler", "Exception");
					e.printStackTrace();
					if(onResponseReceivedListener!=null)
						onResponseReceivedListener.onResponseReceived("No response", false);
				}
				Looper.loop(); //Loop in the message queue
			}
		};
		t.start();      
	}
	
	public interface OnResponseReceivedListener {
	    public abstract void onResponseReceived(String receivedString, boolean success);
	    public abstract void onIOException();
	}
	
	public void setOnResponseReceivedListener(OnResponseReceivedListener listener) {
	    onResponseReceivedListener = listener;
	}
}
