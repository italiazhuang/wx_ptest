// JavaScript Document

$(window).load(function() {
	 
});

$(document).ready(function () {
	$('#tweets').tweetable({username: 'iEnabled', time: true, limit: 3, replies: true, position: 'append'});

	$("#home").click(function() { 
		$(this).addClass('selected');
		$("#homeDiv").css("display","block");
		$("#picwordsDiv").css("display","none");
		$("#comunityDiv").css("display","none");
		$("#minwallDiv").css("display","none");
		$("#myDiv").css("display","none");
		$(this).parent().parent().find('#picwords, #comunity, #minwall, #my').removeClass('selected');
		$(this).parent().parent().find(".home").show();
		$(this).parent().parent().find(".picwords").hide();
		$(this).parent().parent().find(".comunity").hide();
		$(this).parent().parent().find(".minwall").hide();
		$(this).parent().parent().find(".my").hide();
	});
	$("#picwords").click(function() { 
		$(this).addClass('selected');
		$("#picwordsDiv").css("display","block");
		$("#homeDiv").css("display","none");
		$("#comunityDiv").css("display","none");
		$("#minwallDiv").css("display","none");
		$("#myDiv").css("display","none");
		$(this).parent().parent().find('#home, #comunity, #minwall, #my').removeClass('selected');
		$(this).parent().parent().find(".home").hide();
		$(this).parent().parent().find(".picwords").show();
		$(this).parent().parent().find(".comunity").hide();
		$(this).parent().parent().find(".minwall").hide();
		$(this).parent().parent().find(".my").hide();
	});
	$("#comunity").click(function() { 
		$(this).addClass('selected');
		$("#picwordsDiv").css("display","none");
		$("#homeDiv").css("display","none");
		$("#comunityDiv").css("display","block");
		$("#minwallDiv").css("display","none");
		$("#myDiv").css("display","none");
		$(this).parent().parent().find('#home, #picwords, #minwall, #my').removeClass('selected');
		$(this).parent().parent().find(".home").hide();
		$(this).parent().parent().find(".picwords").hide();
		$(this).parent().parent().find(".comunity").show();
		$(this).parent().parent().find(".minwall").hide();
		$(this).parent().parent().find(".my").hide();
	});
	$("#minwall").click(function() { 
		$(this).addClass('selected');
		$("#picwordsDiv").css("display","none");
		$("#homeDiv").css("display","none");
		$("#comunityDiv").css("display","none");
		$("#minwallDiv").css("display","block");
		$("#myDiv").css("display","none");
		$(this).parent().parent().find('#home, #picwords, #comunity, #my').removeClass('selected');
		$(this).parent().parent().find(".home").hide();
		$(this).parent().parent().find(".picwords").hide();
		$(this).parent().parent().find(".comunity").hide();
		$(this).parent().parent().find(".minwall").show();
		$(this).parent().parent().find(".my").hide();
	});
	$("#my").click(function() { 
		$(this).addClass('selected');
		$("#picwordsDiv").css("display","none");
		$("#homeDiv").css("display","none");
		$("#comunityDiv").css("display","none");
		$("#minwallDiv").css("display","none");
		$("#myDiv").css("display","block");
		$(this).parent().parent().find('#home, #picwords, #comunity, #minwall').removeClass('selected');
		$(this).parent().parent().find(".home").hide();
		$(this).parent().parent().find(".picwords").hide();
		$(this).parent().parent().find(".comunity").hide();
		$(this).parent().parent().find(".minwall").hide();
		$(this).parent().parent().find(".my").show();
	});

	$(".notification-quit-red").click(function(){
	  $(".notification-box-red").fadeOut("slow");
	  return false;
	});
	
	$(".notification-quit-green").click(function(){
	  $(".notification-box-green").fadeOut("slow");
	  return false;
	});
	
	$(".notification-quit-yellow").click(function(){
	  $(".notification-box-yellow").fadeOut("slow");
	  return false;
	});
	
	$(".notification-quit-blue").click(function(){
	  $(".notification-box-blue").fadeOut("slow");
	  return false;
	});
	

 



});


















