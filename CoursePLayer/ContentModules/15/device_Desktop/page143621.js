if (window.VarCurrentView) VarCurrentView.set('Desktop');
function init_Desktop() {
	if ( rcdObj.view != 'Desktop' ) return;
	if (!isOPAPub() || isLOPopup()) window.init_page();
	preload(rcdObj['preload_'+rcdObj.view]);
}
function defineFuncs_Desktop() {
	if ( rcdObj.view != 'Desktop' ) return;
	try{
		if (window.initGEV)
		{
		 initGEV(0,swipeLeft,swipeRight);
	swipeLeft = function(){
		try {action31985()} catch(e){}
	}
	swipeRight = function(){
		try {action137336()} catch(e){}
	}
		initGEV(1,swipeLeft,swipeRight);

		}
		} catch(e) { if (window.console) window.console.log(e); }	pageClick = n;
	pageRClick = n;
	pageKey = n;
	pageKey = function(e,keyVal,keyFlags) {
		var keyAvail = true;
		if( keyFlags == 0 && keyVal == 39 ){action137338(); keyAvail = false; };

    if( keyFlags == 0 && keyVal == 37 ){action137337(); keyAvail = false; };

		return keyAvail;
	};
}
og148932.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"",
	cssClasses:	"",
	htmlId:		"og148932",
	bInsAnc:	undefined,
	objData:	{"a":[0,32,0,[]],"bReadLast":false}
};
og28117.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"",
	cssClasses:	"",
	htmlId:		"og28117",
	bInsAnc:	undefined,
	objData:	{"a":[0,32,0,[]],"bReadLast":false}
};
shape146877.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 1009 608\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(504.5 304)\" style=\"\">\n	<path d=\"M 0 0 L 1008 0 L 1008 607 L 0 607 L 0 0 Z\" style=\"stroke: rgb(219, 102, 39); stroke-width: 1; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(255, 255, 255); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-504, -303.5) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(504.5 304)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"visibility: inherit; position: absolute; left: -0.5px; top: -0.5px; width: 1009px; height: 608px; z-index: 1; overflow: visible; pointer-events: none;",
	cssClasses:	"",
	htmlId:		"tobj146877",
	bInsAnc:	0,
	cwObj:		{
		"name":	"kaderlijn"
	},
	objData:	{"a":[0,32,0,[-0.5000000000003979,-0.4999999999992042,1009,608]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":0,"y":0,"width":1009,"height":608},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape146877.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
shape137392.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 1009 45\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(504.5 22.5)\" style=\"\">\n	<path d=\"M 0 0 L 1009 0 L 1009 45 L 0 45 L 0 0 Z\" style=\"stroke: rgb(1, 102, 177); stroke-width: 0; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(219, 102, 39); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-504.5, -22.5) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(504.5 22.5)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"visibility: inherit; position: absolute; left: 0px; top: 8.70415e-13px; width: 1009px; height: 45px; z-index: 2; overflow: visible; pointer-events: none;",
	cssClasses:	"",
	htmlId:		"tobj137392",
	bInsAnc:	0,
	cwObj:		{
		"name":	"headerbackground"
	},
	objData:	{"a":[0,160,0,[0,8.704148513061227e-13,1009,45]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":0,"y":0,"width":1009,"height":45},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape137392.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
shape137498.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 1007 34\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(503.5 17)\" style=\"\">\n	<path d=\"M 0 0 L 1007 0 L 1007 34 L 0 34 L 0 0 Z\" style=\"stroke: rgb(1, 102, 177); stroke-width: 0; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(238, 238, 238); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-503.5, -17) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(503.5 17)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"visibility: inherit; position: absolute; left: 1px; top: 45px; width: 1007px; height: 34px; z-index: 3; overflow: visible; pointer-events: none;",
	cssClasses:	"",
	htmlId:		"tobj137498",
	bInsAnc:	0,
	cwObj:		{
		"name":	"subheaderbackground"
	},
	objData:	{"a":[0,160,0,[1,45.00000000000087,1007,34]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":1,"y":45,"width":1007,"height":34},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape137498.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
button146730.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj146730Img\" src=\"images/btn-close143187.png\" style=\"position: absolute; left: 0px; top: 0px; width: 20px; height: 20px; border-style: none;\">",
	cssText:	"visibility: inherit; position: absolute; left: 975px; top: 14px; width: 20px; height: 20px; z-index: 4; cursor: pointer;",
	cssClasses:	"",
	htmlId:		"tobj146730",
	bInsAnc:	1,
	cwObj:		{
		"name":	"btn-close",
		"arChld":
	[
		{type:6,on:2,delay:0,name:'OnMClkExitClose',actItem:function(){ {trivScormQuit(false, 'page1.html', true);} 
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[4,288,0,[975,14,20,20]],"rcdOvr":{"res":0},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":975,"y":14,"width":20,"height":20},"res":"images/btn-close143187.png","resClick":"images/btn-close143187.png","resOver":"images/btn-close-hover143188.png"}
};
image147010.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj147010Img\" src=\"images/logo-roodbont.png\" style=\"position: absolute; border-style: none; left: 0px; top: 0px; width: 135px; height: 21px;\">",
	cssText:	"visibility: hidden; position: absolute; left: 852px; top: 52px; width: 135px; height: 21px; z-index: 5;",
	cssClasses:	"",
	htmlId:		"tobj147010",
	bInsAnc:	0,
	cwObj:		{
		"name":	"logo-roodbont"
	},
	objData:	{"a":[0,256,0,[852,52,135,21]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":852,"y":52,"width":135,"height":21}}
};
image148817.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj148817Img\" src=\"images/logo-Aeres.png\" style=\"position: absolute; border-style: none; left: 0px; top: 0px; width: 140px; height: 61px;\">",
	cssText:	"visibility: inherit; position: absolute; left: 826px; top: 9px; width: 140px; height: 61px; z-index: 6;",
	cssClasses:	"",
	htmlId:		"tobj148817",
	bInsAnc:	0,
	cwObj:		{
		"name":	"logo-Aeres"
	},
	objData:	{"a":[0,288,0,[826,9,140,61]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":826,"y":9,"width":140,"height":61}}
};
button352.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj352Img\" src=\"images/prev.png\" style=\"position: absolute; left: 0px; top: 0px; width: 34px; height: 34px; border-style: none;\">",
	cssText:	"visibility: inherit; position: absolute; left: 25px; top: 554px; width: 34px; height: 34px; z-index: 16; cursor: pointer;",
	cssClasses:	"",
	htmlId:		"tobj352",
	bInsAnc:	1,
	cwObj:		{
		"name":	"prev page",
		"arChld":
	[
		{type:6,on:2,delay:0,name:'OnMClkGoTo',actItem:function(){ trivExitPage('page143127.html',false,false);
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[4,352,0,[25,554,34,34]],"rcdOvr":{"res":0},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":25,"y":554,"width":34,"height":34},"res":"images/prev.png","resClick":"images/prev.png","resOver":"images/prevHover.png"}
};
button353.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj353Img\" src=\"images/next.png\" style=\"position: absolute; left: 0px; top: 0px; width: 34px; height: 34px; border-style: none;\">",
	cssText:	"visibility: inherit; position: absolute; left: 948px; top: 554px; width: 34px; height: 34px; z-index: 17; cursor: pointer;",
	cssClasses:	"",
	htmlId:		"tobj353",
	bInsAnc:	1,
	cwObj:		{
		"name":	"next page",
		"arChld":
	[
		{type:6,on:2,delay:0,name:'OnMClkGoTo',actItem:function(){ trivExitPage('page143625.html',true,false);
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[4,352,0,[948,554,34,34]],"rcdOvr":{"res":0},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":948,"y":554,"width":34,"height":34},"res":"images/next.png","resClick":"images/next.png","resOver":"images/nextHover.png"}
};
progress70386.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 306px; height: 6px;\"><div style=\"overflow: hidden; background-color: rgb(238, 238, 238); position: absolute; left: 0px; top: 0px; border: 1px solid rgb(102, 102, 102); width: 306px; height: 4px;\"><div style=\"overflow: hidden; position: absolute; left: 0px; top: 0px; width: 72px; height: 100%; background-color: rgb(204, 204, 204);\"></div></div><div name=\"dCon2\" style=\"position: absolute; width: 100%; left: 1px; bottom: 0px; height: 6px;\"></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 351px; top: 571px; width: 308px; height: 6px; z-index: 18;",
	cssClasses:	"",
	htmlId:		"tobj70386",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Progress Bar"
	},
	objData:	{"a":[0,16777312,0,[351,571,308,6]],"rcdOvr":{"res":0},"desktopRect":{"x":351,"y":571,"width":308,"height":6},"step":1,"range":30,"barPos":7,"tickTime":1000,"dwBarFlags":4,"imgsrc":"images/indicatie.gif"}
};
text354.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 860px; min-height: 40px;\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 0px; top: 0px; width: 860px; min-height: 40px;\"><p style=\"margin-left:0px;text-indent:0px;margin-top:0px;margin-bottom:0px;\" align=\"left\"><span><strong><span style=\"font-size:22pt; color: rgb(255, 255, 255); font-family: calibri;\">Vleeskuikensignalen -&nbsp;</span></strong><span style=\"color: rgb(255, 255, 255); font-family: calibri; font-size:22pt;\">Water en strooisel</span></span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 50px; top: 5px; width: 860px; height: 40px; z-index: 7;",
	cssClasses:	"",
	htmlId:		"tobj354",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Title module"
	},
	objData:	{"a":[0,32,0,[50,5,860,40]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":50,"y":5,"width":860,"height":40},"dwTextFlags":0,"marginSize":0,"textPublishLang":"Inherit"}
};
text146550.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 900px; min-height: 34px;\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 0px; top: 0px; width: 900px; min-height: 34px;\"><p style=\"margin-left:0px;text-indent:0px;margin-top:0px;margin-bottom:0px;\" align=\"left\"><span style=\"font-size:18pt; color: rgb(102, 102, 102); font-family: calibri;\">Title of chapter</span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 50px; top: 47px; width: 900px; height: 34px; z-index: 8;",
	cssClasses:	"",
	htmlId:		"tobj146550",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Title of Chapter",
		"arChld":
	[
		{type:6,on:11,delay:0,name:'OnPageShowChange',actItem:function(){ text146550.changeContents(VarCurrentChapterName.getValue()); 
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[0,32,0,[50,47,900,34]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":50,"y":47,"width":900,"height":34},"dwTextFlags":0,"marginSize":0,"textPublishLang":"Inherit"}
};
text146548.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 903px; min-height: 27px;\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 0px; top: 0px; width: 903px; min-height: 27px;\"><p leglh=\"1.218\" style=\"margin-left:0px;text-indent:0px;line-height:1.218;margin-top:0px;margin-bottom:0px;\" align=\"left\"><span style=\"font-size:14pt; font-family: calibri;\"><strong><span style=\"color: rgb(0, 0, 0);\">Title of Page</span></strong></span><span style=\" font-size:14pt; font-family:\'Calibri\', sans-serif; color:#000000; \"><strong> </strong></span><span style=\" font-size:14pt; font-family:\'Calibri\', sans-serif; color:#000000;\"> </span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 50px; top: 97px; width: 903px; height: 27px; z-index: 19;",
	cssClasses:	"",
	htmlId:		"tobj146548",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Title of Page",
		"arChld":
	[
		{type:6,on:11,delay:0,name:'OnPageShowChange',actItem:function(){ text146548.changeContents(VarCurrentPageName.getValue()); 
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[0,96,0,[50,97,903,27]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":50,"y":97,"width":903,"height":27},"dwTextFlags":0,"marginSize":0,"textPublishLang":"Inherit"}
};
button148245.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj148245Img\" src=\"images/btn-home.png\" style=\"position: absolute; left: 0px; top: 0px; width: 28px; height: 25px; border-style: none;\">",
	cssText:	"visibility: inherit; position: absolute; left: 10px; top: 10px; width: 28px; height: 25px; z-index: 20; cursor: pointer;",
	cssClasses:	"",
	htmlId:		"tobj148245",
	bInsAnc:	1,
	cwObj:		{
		"name":	"btn-home",
		"arChld":
	[
		{type:6,on:2,delay:0,name:'OnMClkGoTo',actItem:function(){ trivExitPage('page148159.html',true,false);
    if(typeof pF == 'function') pF(); }}
	]
	},
	objData:	{"a":[4,352,0,[10,10,28,25]],"rcdOvr":{"res":0},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":10,"y":10,"width":28,"height":25},"res":"images/btn-home.png","resClick":"images/btn-home.png","resOver":"images/btn-home-H.png"}
};
og148948.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"",
	cssClasses:	"",
	htmlId:		"og148948",
	bInsAnc:	undefined,
	objData:	{"a":[0,32,0,[]],"bReadLast":false}
};
shape148949.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"visibility: inherit; position: absolute; left: 1047px; top: 0px; width: 1009px; height: 608px; z-index: 21;",
	cssClasses:	"",
	htmlId:		"tobj148949",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Rectangle"
	},
	objData:	{"a":[0,16480,0,[1047,0,1009,608]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":1047,"y":0,"width":1009,"height":608}}
};
image148950.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"visibility: inherit; position: absolute; left: 1450px; top: 139px; width: 373px; height: 373px; z-index: 22;",
	cssClasses:	"",
	htmlId:		"tobj148950",
	bInsAnc:	0,
	cwObj:		{
		"name":	"rotate-mobile"
	},
	objData:	{"a":[0,352,0,[1450,139,373,373]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":1450,"y":139,"width":373,"height":373}}
};
text147188.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 440px; height: 100px; background-color: rgb(249, 203, 156);\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 8px; top: 8px; width: 424px; height: 84px;\"><p style=\"text-align:left\"><span><span style=\"font-family: calibri; font-size:12pt;\">Een vuistregel voor de doorstroomsnelheid is de leeftijd van de kuikens in dagen plus 20 ml/min.&nbsp;</span></span></p><p style=\"text-align:left\"><span style=\"font-family: calibri; font-size:12pt;\">​</span></p><p style=\"text-align:left\"><span style=\"font-family: calibri; font-size:12pt;\">Bijvoorbeeld: 35 dagen + 20 = 55 ml/minuut.</span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 50px; top: 320px; width: 440px; height: 100px; z-index: 9;",
	cssClasses:	"",
	htmlId:		"tobj147188",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Text Block 3"
	},
	objData:	{"a":[0,32,0,[50,320,440,100]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":50,"y":320,"width":440,"height":100},"dwTextFlags":0,"marginSize":8,"textPublishLang":"Inherit"}
};
text144737.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 440px; min-height: 32px;\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 0px; top: 0px; width: 440px; min-height: 32px;\"><p style=\"text-align:left\"><span><em><span style=\"color:#000000;font-family:calibri,open sans,opensans;font-size:12pt;\">Er zijn eenvoudige hulpmiddelen om de watergift te meten.&nbsp;</span></em></span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 525px; top: 460px; width: 440px; height: 32px; z-index: 10;",
	cssClasses:	"",
	htmlId:		"tobj144737",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Text Block 4"
	},
	objData:	{"a":[0,32,0,[525,460,440,32]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":525,"y":460,"width":440,"height":32},"dwTextFlags":0,"marginSize":0,"textPublishLang":"Inherit"}
};
image146288.rcdData.att_Desktop = 
{
	innerHtml:	"<img id=\"tobj146288Img\" src=\"images/nippeltester-2-LR.jpg\" style=\"position: absolute; border-style: none; left: 0px; top: 0px; width: 440px; height: 330px;\">",
	cssText:	"visibility: inherit; position: absolute; left: 524px; top: 127px; width: 440px; height: 330px; z-index: 11;",
	cssClasses:	"",
	htmlId:		"tobj146288",
	bInsAnc:	0,
	cwObj:		{
		"name":	"nippeltester-2-LR"
	},
	objData:	{"a":[0,288,0,[524,127,440,330]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":524,"y":127,"width":440,"height":330}}
};
og146296.rcdData.att_Desktop = 
{
	innerHtml:	"",
	cssText:	"",
	cssClasses:	"",
	htmlId:		"og146296",
	bInsAnc:	undefined,
	objData:	{"a":[0,32,0,[]],"bReadLast":false}
};
shape146290.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 104 101\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(52 50.5)\" style=\"\">\n	<path d=\"M 0 49 A 50.5 49 0 1 1 101 49 A 50.5 49 0 1 1 0 49 Z\" style=\"stroke: rgb(255, 255, 0); stroke-width: 3; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(255, 255, 255); fill-opacity:0;filter:alpha(opacity=0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-50.5, -49) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(52 50.5)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"left: 540.5px; top: 347.5px; visibility: hidden; position: absolute; width: 104px; height: 101px; z-index: 12; overflow: visible; pointer-events: none;",
	cssClasses:	"",
	htmlId:		"tobj146290",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Ellipse"
	},
	objData:	{"a":[32,32,[7,0,2,0,0,0],[540.5,347.5,104,101]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":542,"y":349,"width":104,"height":101},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape146290.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
shape146295.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 95 45\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(47.5 22.5)\" style=\"\">\n	<path d=\"M 0 0 L 93 43\" style=\"stroke: rgb(255, 255, 0); stroke-width: 2; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(255, 255, 0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-46.5, -21.5) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(47.5 22.5) matrix(1 0 0 -1 0 0)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"visibility: inherit; position: absolute; left: 642px; top: 339px; width: 95px; height: 45px; z-index: 13; transform: scaleY(-1); overflow: visible; pointer-events: none;; behavior:url(-ms-transform.htc); -moz-transform:ScaleY(-1); -webkit-transform:ScaleY(-1); -o-transform:ScaleY(-1); -ms-transform:ScaleY(-1); filter:flipv; -ms-filter:flipv",
	cssClasses:	"",
	htmlId:		"tobj146295",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Line"
	},
	objData:	{"a":[0,32,0,[642,339,95,45]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":643,"y":340,"width":95,"height":45},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape146295.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
shape146291.rcdData.att_Desktop = 
{
	innerHtml:	"<svg viewBox=\"0 0 201 196\" preserveAspectRatio=\"none\" focusable=\"false\" style=\"pointer-events: none; left: 0px; top: 0px; width: 100%; height: 100%; position: absolute;\"><g transform=\"translate(100.5 98)\" style=\"\">\n	<path d=\"M 0 96.5 A 99 96.5 0 1 1 198 96.5 A 99 96.5 0 1 1 0 96.5 Z\" style=\"stroke: rgb(255, 255, 0); stroke-width: 3; stroke-dasharray: none; stroke-linecap: round; stroke-linejoin: round; stroke-miterlimit: 10; fill: rgb(255, 255, 255); fill-opacity:0;filter:alpha(opacity=0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100); pointer-events: auto;\" transform=\"translate(0 0) translate(-99, -96.5) \" stroke-linecap=\"round\"></path>\n</g>\n	<g transform=\"translate(100.5 98)\">\n		<text font-family=\"Arial,sans-serif\" font-size=\"15.9999996\" font-weight=\"normal\" style=\"stroke: none; stroke-width: 1; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill: rgb(0,0,0); fill-rule: nonzero; opacity:1;filter:alpha(opacity=100);\">\n			<tspan x=\"0\" y=\"5.04\" fill=\"#000000\"></tspan>\n		</text>\n	</g>\n</svg>",
	cssText:	"left: 725.5px; top: 205.5px; visibility: hidden; position: absolute; width: 201px; height: 196px; z-index: 14; overflow: visible; pointer-events: none;",
	cssClasses:	"",
	htmlId:		"tobj146291",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Ellipse"
	},
	objData:	{"a":[32,32,[7,0,7,0,0,0],[725.5,205.50000000000003,201,196]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":727,"y":207,"width":201,"height":196},"btnState":"disabled","fallbackImg":"<img src=\"images/desktop_shape146291.png\" alt=\"\" title=\"\" style=\"position: absolute; width: 100%; height: 100%; top: 0px; left: 0px;\">"}
};
text143622.rcdData.att_Desktop = 
{
	innerHtml:	"<div name=\"dCon\" style=\"position: absolute; left: 0px; top: 0px; width: 440px; min-height: 195px;\"><div name=\"dCon2\" class=\"ttxt\" style=\"left: 0px; top: 0px; width: 440px; min-height: 195px;\"><p style=\"text-align:left\"><span style=\"font-family: calibri; font-size:12pt;\">Als er te weinig water uit de nippels komt, drinken de kuikens te weinig. Controleer regelmatig de waterdruk en de watergift van de nippels. Je kunt de doorstroomsnelheid beoordelen door een bakje een minuut tegen een nippel te houden. Doe dat bij verschillende drinklijnen. </span></p><p style=\"text-align:left\"><span><span style=\"font-family: calibri; font-size:12pt;\">Te veel waterafgifte geeft vermorsing en een slechtere strooiselkwaliteit en daardoor weer een slechtere kuikenkwaliteit en voetzoollaesies. Laat het drinkwater door een laboratorium controleren.&nbsp;</span></span></p></div></div>",
	cssText:	"visibility: inherit; position: absolute; left: 50px; top: 125px; width: 440px; height: 195px; z-index: 15;",
	cssClasses:	"",
	htmlId:		"tobj143622",
	bInsAnc:	0,
	cwObj:		{
		"name":	"Text Block 1"
	},
	objData:	{"a":[0,32,0,[50,125,440,195]],"rcdOvr":{"res":0},"borderEffect":{"outline":0,"outlineColor":"#000000","borderWeight":0,"lineStyle":0,"borderColor":"#000000"},"rotateEffect":{"angle":0,"anchorX":50,"anchorY":50},"desktopRect":{"x":50,"y":125,"width":440,"height":195},"dwTextFlags":0,"marginSize":0,"textPublishLang":"Inherit"}
};
rcdObj.rcdData.att_Desktop = 
{
	font:	{"bold":0,"italic":0,"underline":0,"size":"12","color":null,"bgColor":null,"name":"'Calibri'","lineHeight":"1.25","marginTop":"0px","marginBottom":"0px"},
	pageIdx:	7
};
rcdObj.pgWidth_Desktop = pgWidth_desktop;
rcdObj.preload_Desktop = ["images/prev.png","images/next.png","images/prevHover.png","images/nextHover.png","images/indicatie.gif","images/nippeltester-2-LR.jpg","images/btn-close143187.png","images/btn-close-hover143188.png","images/logo-roodbont.png","images/btn-home.png","images/btn-home-H.png","images/logo-Aeres.png","images/shape9278.png","images/shape148517.png","images/shape9277.png","images/shape148518.png"];
rcdObj.pgStyle_Desktop = 'position: absolute; left: 0px; top: 0px; width: 1009px; height: 609px; overflow: hidden; background-size: auto;'
rcdObj.backgrd_Desktop = ["#eeeeee","",0,0,1];
