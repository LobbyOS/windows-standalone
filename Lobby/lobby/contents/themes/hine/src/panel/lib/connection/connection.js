function checkNetConnection(){re="";r=Math.round(Math.random()*10000);$.get("http://lobby.subinsb.com/api/dot.gif",{subins:r},function(d){}).error(function(){$(".panel.top .right #net").addClass("off").attr("title","Offline");});}
checkNetConnection();