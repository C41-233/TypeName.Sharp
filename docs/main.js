(function(){

$(function(){
	var template = $("#template-source-table").html()
	Mustache.parse(template)
	
	$(".div-source").each(function(){
		var $this = $(this)
		var src = $this.data("src")
		$.getJSON(src, function(data){
			$this.append(Mustache.render(template, {data:data}))
		})
	})
})

})();