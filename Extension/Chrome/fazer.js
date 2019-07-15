


var pagina = $("#page-content h2").html();

var lista = [];

if(pagina == "Gerenciar inventário atual"){
    
    $(".width100 tbody tr").each(function(i,obj){ 
        var cod = $(obj).find("td:eq(1)").html();
        var qtd = $(obj).find("td:eq(4)").find("input").val();
        if(cod !== undefined){
            lista.push( { Codigo: cod, Quantidade: qtd  }); 
        }
    })
    
    chrome.runtime.sendMessage({ Tipo: "baixar", json: JSON.stringify(lista), name: "estoque.json"  });

} else {
    
    $("tr.status-success").each(function(i,obj){ 
        var cod = $(obj).find("td:eq(2)").html();
        var qtd = $(obj).find("td:eq(0)").html();
        if(cod !== undefined && cod !== ""){
            lista.push( { Codigo: cod, Quantidade: qtd  }); 
        }
    })

    var ribe = $(".tile dl:eq(0) dd:eq(0)").html();

    chrome.runtime.sendMessage({ Tipo: "baixar", json: JSON.stringify(lista), name: ribe + ".json"  });


}
	


