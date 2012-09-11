﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" MasterPageFile="~/Site.master" Inherits="twoCube.Sample" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style>img{  }</style>
  <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
  <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
  <script src="https://raw.github.com/SamWM/jQuery-Plugins/master/numeric/jquery.numeric.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to twocube™</h2>
        <p></p>
    <div id="survey" style="width: 800px; display: block;"></div>
    <script>
$.getJSON("./Services/SampleService.asmx/SampleSurvey",
  {
    Name: "treexchg",
    Email: "anysfhfgh",
  },
  function(data) {
  console.log(data);
    $("<h2>" + data.surveyTitle + "</h2>").appendTo("#survey");
    $("<strong>" + data.surveyDescription + "</strong>").appendTo("#survey");

    $.each(data.surveyQuestionList, function(qnvali,qnval){
	  $("<p>" + qnval.surveyQuestionTitle + "</p>").appendTo("#survey");
      if(qnval.surveyQuestionType == 1){
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
            if(optval.surveyQuestionOptionType == 2){
                $("<input type=\"radio\" name=\""+qnvali+"\" value=\""+i+"\" id=\"" + qnvali + i + "\" /><label for=\""+qnvali + i+"\">" + optval.surveyQuestionOptionTitle + "</label><br/><input type=\"text\" name=\"" + qnvali + i + "\"/>").appendTo("#survey");
            }else{
                 $("<input type=\"radio\" name=\""+qnvali+"\" value=\""+i+"\" id=\"" + qnvali + i + "\" /><label for=\""+qnvali + i+"\">" + optval.surveyQuestionOptionTitle + "</label><br/>").appendTo("#survey");
            }
	     

        });
      }else if (qnval.surveyQuestionType == 2){
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
	      $("<input type=\"checkbox\" name=\""+ qnvali + i +"\" value=\""+ qnvali + i +"\" id=\"" + qnvali + i + "\" />" + optval.surveyQuestionOptionTitle + "<br/>").appendTo("#survey");

        });
      }else if (qnval.surveyQuestionType == 3){
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
	        $("<div id=\"slider"+qnvali+"\"></div><span style=\"float: left;\">Hardworking</span><span style=\"float: right;\">Most Hardworking</span><br/>").appendTo("#survey");
            $("#slider"+qnvali).slider();
        });
      }else if (qnval.surveyQuestionType == 4){
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
            $("<div id=\""+qnvali+"\" style=\"clear:both;\"></div>").appendTo("#survey");
	        $("<input class=\"integer\" type=\"text\" /><br/>").appendTo("#"+qnvali);
            $("<img/>").attr("src",optval.surveyQuestionOptionTitle).appendTo("#"+qnvali);
            $("<p style=\"clear:both;\"> </p>").appendTo("#"+qnvali);
            $(".integer").numeric(false, function() { alert("Integers only"); this.value = ""; this.focus(); });
        });
      }else if (qnval.surveyQuestionType == 5){
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
            $("<div id=\""+qnvali+"\" style=\"clear:both;\"></div>").appendTo("#survey");
	        $("<input id=\"datepicker"+qnvali+"\" type=\"text\"/><br/>").appendTo("#"+qnvali);
            $("<img/>").attr("src",optval.surveyQuestionOptionTitle).appendTo("#"+qnvali);
            $("<p style=\"clear:both;\"> </p>").appendTo("#"+qnvali);
            $( "#datepicker"+qnvali).datepicker();
        });
      }else if(qnval.surveyQuestionType == 6){
        $("<div id=\""+qnvali+"\" style=\"clear:both\"></div>").appendTo("#survey");
        $.each(qnval.surveyQuestionOptionList, function(i,optval){
            $("<div class=\"rad\" style=\"display:inline-block; width:70px;\"><label for=\""+qnvali + i+"\" style=\"display:block; width:70px; text-align:center;\"><img src=\"" + optval.surveyQuestionOptionTitle + "\"></label><input type=\"radio\" style=\"width:70px; text-align:center;\" name=\""+qnvali+"\" value=\""+i+"\" id=\"" + qnvali + i + "\" /></div>").appendTo("#"+qnvali);
        });
      }
    });
  });</script>

    </asp:Content>