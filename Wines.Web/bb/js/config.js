window.CellarConfig = {
  status: 'remote', // debug|prod|remote
  debug: 'http://localhost:50056',
  prod: 'http://localhost/wines',
  remote: 'http://10.100.1.183/wines',
  getEndPoint: function() {
    return this[this.status];
  }
};
