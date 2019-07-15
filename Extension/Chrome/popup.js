var lista = localStorage.getItem("publicacoes");

if(lista !== null){
    lista = JSON.parse(lista);
} else {
    lista = [];
}

var informandoPublicacao = true;
var publicacao = {};

$(document).ready(function(){

    populaPublicacoes();

    $('#campo').keypress(function(event){
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if(keycode == '13'){

            if(informandoPublicacao){

                this.placeholder = "Quantidade";
                
                publicacao = {Codigo: this.value, Qtd: "Informe..."};
                lista.push(publicacao);     

            } else {

                this.placeholder = "Codigo";

                if(publicacao.Codigo.toUpperCase().indexOf("T-") == 0 ){
                    publicacao.Qtd = this.value*12;  
                } else {
                    publicacao.Qtd = this.value;  
                }    

            }

            this.value = "";
            informandoPublicacao = !informandoPublicacao;
            populaPublicacoes();
            salvarPublicacoes();
        }
    });

    registrarEventoRemocao();

    $('#menu a').click(function (e) {
        
        
        
        if (this.text == "Informar Estoque"){
            $("#menu").hide();
        
        } else if (this.text == "Baixar Estoque" || this.text == "Baixar Ribe" ){

           console.log(this.text);
           
           chrome.runtime.sendMessage({ Tipo: "iniciar" });
            
            // chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
            //     chrome.tabs.executeScript(null, { file: "fazer.js" });
            // })
            

        } else if (this.text == "Arredondar Compartilhamento" ){
           console.log(this.text);
           chrome.runtime.sendMessage({ Tipo: "arredondar" });

            // chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
            //     chrome.tabs.executeScript(null, { file: "arredondar.js" });
            // })
        }

        $(this).tab('show')
        
        e.preventDefault();


    })

    $("#limparLista").click(function(){
        if(confirm("Limpar toda a lista?")){                        
            lista = [];
            populaPublicacoes();
            salvarPublicacoes();                    
        }
    });

    $("#enviarLista").click(function(){        
        
        console.log("enviarLista click");

        
        // chrome.runtime.sendMessage({ Tipo: "preencher", dados: lista });
        chrome.runtime.sendMessage({ Tipo: "preencher", dados: lista });

        //var query = { active: true, currentWindow: true };
		// chrome.tabs.executeScript(null, { file: "jquery.min.js" }, function () {
		// 	preencheFormulario();
        // })
        
    })

});

function registrarEventoRemocao(){
    

    $("#publicacoes li").click(function(){

        if(confirm("Deseja realmente remover este registro?")){                        
            var index = $(this).attr('index');
            lista.splice(index, 1);
            populaPublicacoes();
            salvarPublicacoes();                    
        }

    })

}

function salvarPublicacoes(){
    localStorage.setItem("publicacoes", JSON.stringify(lista));
}

function populaPublicacoes(){
    var texto = "";

    $(lista).each(function(i){
        texto += "<li index='"+i+"'>" + this.Codigo + " : " + this.Qtd + "</li>";
    });

    $("#publicacoes").html(texto);
    registrarEventoRemocao();

}


function preencheFormulario(){

    console.log(location.href);

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



}

function arrendondarFormulario(){

    $("input[id*=atxtQty]").each(function(i, o){
        $(this).parents("tr").find("input[id*=atxtShareQty]").val( Math.floor( (o.value * 1) * 0.1 ) )
    })

}
