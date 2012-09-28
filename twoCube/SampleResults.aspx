<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SampleResults.aspx.cs" Inherits="twoCube.SampleResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery.jqplot.min.js"></script>
    <script type="text/javascript" src="Scripts/plugins/jqplot.pieRenderer.js"></script>
    <script type="text/javascript" src="Scripts/plugins/jqplot.barRenderer.js"></script>
    <script type="text/javascript" src="Scripts/plugins/jqplot.categoryAxisRenderer.js"></script>
    <script type="text/javascript" src="Scripts/plugins/jqplot.categoryAxisRenderer.js"></script>
    <link rel="Stylesheet" type="text/css" href="Styles/jquery.jqplot.min.css" />
    <script class="code" type="text/javascript">
        $(document).ready(function () {
            var data = [
    ['June', 300], ['Wei Leng', 9], ['Wesley', 14],
    ['Lim Guan', 16], ['Tiffany', 7], ['Jia De', 1]
  ];

            var total = 0;
            $(data).map(function () { total += this[1]; })

            myLabels = $.makeArray($(data).map(function () { return this[1] + " " + Math.round(this[1] / total * 100) + "%"; }));
            var plot1 = jQuery.jqplot('chart1', [data],
    {
        seriesDefaults: {
            // Make this a pie chart.
            renderer: jQuery.jqplot.PieRenderer,
            rendererOptions: {
                dataLabels: myLabels,
                dataLabelThreshold: 0,
                dataLabelNudge: 20,
                // Put data labels on the pie slices.
                // By default, labels show the percentage of the slice.
                showDataLabels: true
            }
        },
        legend: { show: true, location: 'e' }
    }
  );
        });
</script>

  <style type="text/css">
    
    .note {
        font-size: 0.8em;
    }
    .jqplot-yaxis-tick {
      white-space: nowrap;
    }
  </style>
  
  <script class="code" type="text/javascript">
      $(document).ready(function () {
          var s1 = [200];
          var s2 = [460];
          var s3 = [260];
          // Can specify a custom tick Array.
          // Ticks should match up one for each y value (category) in the series.
          var ticks = ['Question 4'];

          var plot1 = $.jqplot('chart2', [s1, s2, s3], {
              // The "seriesDefaults" option is an options object that will
              // be applied to all series in the chart.
              seriesDefaults: {
                  renderer: $.jqplot.BarRenderer,
                  rendererOptions: { fillToZero: true }
              },
              // Custom labels for the series are specified with the "label"
              // option on the series option.  Here a series option object
              // is specified for each series.
              series: [
            { label: 'June' },
            { label: 'June' },
            { label: 'June' }
        ],
              // Show the legend and put it outside the grid, but inside the
              // plot container, shrinking the grid to accomodate the legend.
              // A value of "outside" would not shrink the grid and allow
              // the legend to overflow the container.
              legend: {
                  show: true,
                  placement: 'outsideGrid'
              },
              axes: {
                  // Use a category axis on the x axis and use our custom ticks.
                  xaxis: {
                      renderer: $.jqplot.CategoryAxisRenderer,
                      ticks: ticks
                  },
                  // Pad the y axis just a little so bars can get close to, but
                  // not touch, the grid boundaries.  1.2 is the default padding.
                  yaxis: {
                      pad: 1.05,
                      tickOptions: { formatString: '%d' }
                  }
              }
          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Who is the most hardworking person in our team?</h2>
<div id="chart1" style="height:300px; width:500px;"></div>
<div class="code prettyprint">
<pre class="code prettyprint brush: js"></pre>

<h2>Who is the most hardworking person in our team? Bar Chart</h2>
<div id="chart2" style="width:600px; height:250px;"></div>
<div class="code prettyprint">
    <pre class="code prettyprint brush: js"></pre>
</div>
</div>
</asp:Content>
