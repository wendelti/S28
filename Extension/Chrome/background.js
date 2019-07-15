// Copyright (c) 2012 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

// Global variables only exist for the life of the page, so they get reset
// each time the page is unloaded.
var counter = 1;
var lastTabId = -1;
var PushWindowId = -1;

i = 0;

function generateFile(docContent, name){

	// let docContent = JSON.stringify(lista); 
	let doc = URL.createObjectURL( new Blob([docContent], {type: 'text/json'}) );
	chrome.downloads.download({ url: doc, filename: name, conflictAction: 'overwrite', saveAs: true });

}

chrome.browserAction.onClicked.addListener(function() {

    chrome.tabs.executeScript(null, { file: "iniciar.js" })

});

chrome.commands.onCommand.addListener(function(command) {
  
	console.log(command);

  chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
	  
		if(command == "Pular"){
			chrome.tabs.executeScript(null, { file: "pular.js" });
		} else if(command == "Fazer"){
			chrome.tabs.executeScript(null, { file: "iniciar.js" })
		}  
	  
  })
	
});




chrome.runtime.onMessage.addListener(function (msg, _, sendResponse) {

	console.log('destino popup: ', msg);
	
	if( msg.Tipo == "iniciar" ){
		 
		chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
			chrome.tabs.executeScript(null, { file: "fazer.js" });
		})
		 
	 } else if( msg.Tipo == "arredondar" ){
		 
		chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
			chrome.tabs.executeScript(null, { file: "arredondar.js" });
		})
		 
	} else if( msg.Tipo == "baixar" ){
		 
		generateFile(msg.json, msg.name);
		 
	} else if( msg.Tipo == "preencher" ){
		 
		
		// chrome.storage.local.set({
		// 	updateTextTo: updateTextTo
		// }, function () {
		// 	chrome.tabs.executeScript({
		// 		file: "content_script3.js"
		// 	});
		// });
		
		chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
			
			
			chrome.tabs.executeScript(null, {
				code: 'var lista = ' + JSON.stringify(msg.dados)
			}, function() {
				chrome.tabs.executeScript(null, {file: 'preencher.js'});
			});

			// chrome.tabs.executeScript(null, { file: "preencher.js" });
		})

		
	 } else {
		console.log(msg);
	 }

	 
});


function preencheFormulario(lista){

	chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {

		var encontrados = [];
		var naoEncontrados = [];

		$(lista).each(function(i, obj){

			var elemento = $("#frmInvMaintain table tbody td").filter(function() {
				return $(this).text().toUpperCase() === obj.Codigo.toUpperCase();
			});
			
			if(elemento.length > 0){
				encontrados.push(obj);
				$(elemento).addClass("encontrado");
				$(elemento).parents("tr").find("input[id*=atxtQty]").val(obj.Qtd);
			} else {
				naoEncontrados.push(obj);
			}



		})

		$("#frmInvMaintain table tbody tr").each(function(){

			$(this).find("td:eq(0):not(.encontrado)").css("border", "5px red solid");

		})

		console.log("NAO ENCONTRADOS:");
		console.log(naoEncontrados);

	});

}

