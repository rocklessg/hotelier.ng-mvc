var ctx = document.getElementById('lineChart').getContext('2d');
var lineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mar', 'April', 'May', 'June', 'Jul', 'Aug'],
        datasets: [{
            label: 'Total Transactions',
            data: [0.5, 1.5, 3, 1.5, 3, 3, 0, 0],
            backgroundColor: [
                '#FFBB33',
            ],
            borderColor: [
                '#2067A1',
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        },
        legend: {
            display: false
        },
    }
});