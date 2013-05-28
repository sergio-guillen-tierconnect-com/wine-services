window.CellarConfig = {
  status: 'prod', // debug|prod
  debug: 'http://localhost:50056',
  prod: 'http://localhost/wines',
  getEndPoint: function() {
    return this[this.status];
  }
};
