<!--

var thespeed = 5;
var navIE = document.all && navigator.userAgent.indexOf("Firefox")==-1;
var myspeed=0;

$(function(){
		
		//蹇嵎鑿滃崟
		bindQuickMenu();
		
		//宸︿晶鑿滃崟寮€鍏?
		LeftMenuToggle();
		
		//鍏ㄩ儴鍔熻兘寮€鍏?
		AllMenuToggle();

		//鍙栨秷鑿滃崟閾炬帴铏氱嚎
		$(".head").find("a").click(function(){$(this).blur()});
		$(".menu").find("a").click(function(){$(this).blur()});
		
		/*
		//杞藉叆婊氬姩娑堟伅
		$.get('getdedesysmsg.php',function(data){
			if(data != ''){
				$(".scroll").html(data);
				$(".scroll").Scroll({line:1,speed:500,timer:3000});
			}
			else
			{
				$(".scroll").html("鏃犳硶璇诲彇缁囨ⅵ瀹樻柟娑堟伅");
			}
		});
		*/
		
		
	}).keydown(function(event){//蹇嵎閿?
		if(event.keyCode ==116 ){
			//url = $("#main").attr("src");
			//main.location.href = url;
			//return false;	
		}
		if(event.keyCode ==27 ){
			$("#qucikmenu").slideToggle("fast")
		}
});
	
function bindQuickMenu(){//蹇嵎鑿滃崟
		$("#ac_qucikmenu").bind("mouseenter",function(){
			$("#qucikmenu").slideDown("fast");
		}).dblclick(function(){
			$("#qucikmenu").slideToggle("fast");
		}).bind("mouseleave",function(){
			hidequcikmenu=setTimeout('$("#qucikmenu").slideUp("fast");',700);
			$(this).bind("mouseenter",function(){clearTimeout(hidequcikmenu);});
		});
		$("#qucikmenu").bind("mouseleave",function(){
			hidequcikmenu=setTimeout('$("#qucikmenu").slideUp("fast");',700);
			$(this).bind("mouseenter",function(){clearTimeout(hidequcikmenu);});
		}).find("a").click(function(){
			$(this).blur();
			$("#qucikmenu").slideUp("fast");
			//$("#ac_qucikmenu").text($(this).text());
		});
}
	
function LeftMenuToggle(){//宸︿晶鑿滃崟寮€鍏?
		$("#togglemenu").click(function(){
			if($("body").attr("class")=="showmenu"){
				$("body").attr("class","hidemenu");
				$(this).html("鏄剧ず鑿滃崟");
			}else{
				$("body").attr("class","showmenu");
				$(this).html("闅愯棌鑿滃崟");
			}
		});
	}
	
	
function AllMenuToggle(){//鍏ㄩ儴鍔熻兘寮€鍏?
		mask = $(".pagemask,.iframemask,.allmenu");
		$("#allmenu").click(function(){
				mask.show();
		});
		//mask.mousedown(function(){alert("123");});
		mask.click(function(){mask.hide();});
}
	
function AC(act){	
		//alert(act);
		mlink = $("a[id='"+act+"']");	
		if(mlink.size()>0){
			box = mlink.parents("div[id^='menu_']");
			boxid = box.attr("id").substring(5,128);
			if($("body").attr("class")!="showmenu")$("#togglemenu").click();
			if(mlink.attr("_url")){
				$("#menu").find("div[id^=menu]").hide();
				box.show();
				mlink.addClass("thisclass").blur().parents("#menu").find("ul li a").not(mlink).removeClass("thisclass");
				if($("#mod_"+boxid).attr("class")==""){
					$("#nav").find("a").removeClass("thisclass");
					$("#nav").find("a[id='mod_"+boxid+"']").addClass("thisclass").blur();
				}
				main.location.href = mlink.attr("_url");
			}else if(mlink.attr("_open") && mlink.attr("_open")!=undefined){
				window.open(mlink.attr("_open"));
			}
		}
}
	

/*********************
 * 婊氬姩鎸夐挳璁剧疆
*********************/

function scrollwindow()
{
	parent.frames['menu'].scrollBy(0,myspeed);
}

function initializeIT()
{
	if (myspeed!=0) {
		scrollwindow();
	}
}


//婊氬姩鎻掍欢
/*
(function($){
	$.fn.extend({
		Scroll:function(opt,callback){
			//鍙傛暟鍒濆鍖?
			if(!opt) var opt={};
			var _this=this.eq(0).find("ul:first");
			var	lineH=_this.find("li:first").height(), //鑾峰彇琛岄珮
				line=opt.line?parseInt(opt.line,10):parseInt(this.height()/lineH,10), //姣忔婊氬姩鐨勮鏁帮紝榛樿涓轰竴灞忥紝鍗崇埗瀹瑰櫒楂樺害
				speed=opt.speed?parseInt(opt.speed,10):500, //鍗峰姩閫熷害锛屾暟鍊艰秺澶э紝閫熷害瓒婃參锛堟绉掞級
				timer=opt.timer?parseInt(opt.timer,10):3000; //婊氬姩鐨勬椂闂撮棿闅旓紙姣锛?
				if(line==0) line=1;
				var upHeight=0-line*lineH;
				//婊氬姩鍑芥暟
				scrollUp=function(){
					_this.animate({
						marginTop:upHeight
					},speed,function(){
						for(i=1;i<=line;i++){
							_this.find("li:first").appendTo(_this);
						}
						_this.css({marginTop:0});
					});
				}
				//榧犳爣浜嬩欢缁戝畾
				var timerID;
				timerID=setInterval("scrollUp()",timer);
				_this.mouseover(function(){
					clearInterval(timerID);			 
				}).mouseout(function(){
					timerID=setInterval("scrollUp()",timer);
				});
		}
	})
})(jQuery);
*/

-->
	

	
