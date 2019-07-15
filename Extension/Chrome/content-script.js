function addquerystring(url, key, value) {
	return  url + "login.aspx?" + key + "=" + value;
}

var linkProjeto = $("#txtProjetoLink").val();
var chaveAcesso = $("#txtLoginDataUriPathQueryStringIdHash").val();

window.addEventListener("message", function(event) {
    if (event.data.type) {
		
			
		chrome.runtime.sendMessage({
          Tipo: event.data.action, 
          url: addquerystring(linkProjeto, "par", chaveAcesso)
		});
		
		
		if((event.data.type == "FROM_PAGE")){
			window.location.href = $('#btnAceitar').prop('href');
		}
	  
    }
}, false);