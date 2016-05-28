
function InitChart(input) {
    
    window.google.charts.load('current', { 'packages': ['corechart'] });
    window.google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var data = [['День', 'Траффик (мб)']];
        for (var i = 0; i < input.length; i++) {
            var traffic = input[i] / 1024;
            data[i + 1] = [i + 1, traffic];
        }
        data = window.google.visualization.arrayToDataTable(data);
        
        var options = {
            hAxis: { title: 'День месяца', titleTextStyle: { color: '#333' } },
            vAxis: { minValue: 0 }
        };

        var chart = new window.google.visualization.AreaChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}