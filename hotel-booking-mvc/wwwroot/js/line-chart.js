var ctx = document.getElementById('lineChart').getContext('2d');
var lineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug'],
        datasets: [{
            data: [0, 1.5, 3, 1.5, 3, 3, 1, 1],
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