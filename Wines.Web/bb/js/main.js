// Models
window.Wine = Backbone.Model.extend({
  urlRoot: CellarConfig.getEndPoint() + '/api/wines',
  defaults: {
    "id" : null,
    "name" : "",
    "grapes" : "",
    "country" : "Bolivia",
    "region" : "Tarija",
    "year" : "",
    "description" : "",
    "picture" : "wine.jpg"
  }
});

window.WineCollection = Backbone.Collection.extend({
  model : Wine,
  url : CellarConfig.getEndPoint() + '/api/wines'
});


/**
 * For the views element, there are two ways to to it,
 * on the #sidebar div put a ul element with an id "wines"
 * and select it in view in the option el with a selector
 * #wines and the second option is remove ul element in #sidebar
 * div and in option tagName use 'ul', it will create a ul for
 * this view
 */
window.WineListView = Backbone.View.extend({
  el: '#wines',

  initialize:function () {
    this.model.bind('reset', this.render, this);
    var self = this;
    // When a new wine is added to the collection,
    // it will appear by binding the "add" event
    this.model.bind('add', function(wine) {
      self.$el.append(new WineListItemView({ model : wine }).render().el);
    });
  },

  render:function (eventName) {
    // When going back, it display append again elements
    this.$el.empty();

    _.each(this.model.models, function (wine) {
      this.$el.append(new WineListItemView({model:wine}).render().el);
    }, this);
    return this;
  }
});

window.WineListItemView = Backbone.View.extend({
  tagName:"li",
  template:_.template($('#tpl-wine-list-item').html()),

  initialize: function() {
    this.model.bind('change', this.render, this);
    this.model.bind('destroy', this.close, this);
  },

  render: function (eventName) {
    $(this.el).html(this.template(this.model.toJSON()));
    return this;
  },

  close: function() {
    this.$el.unbind();
    this.$el.remove();
  }
});

window.WineView = Backbone.View.extend({
  template:_.template($('#tpl-wine-details').html()),

  initialize: function() {
    this.model.bind('change', this.render, this);
  },

  render:function (eventName) {
    $(this.el).html(this.template(this.model.toJSON()));
    return this;
  },

  events: {
    'click .save'   : 'saveWine',
    'click .delete' : 'deleteWine'
  },

  change: function(event) {
    var target = event.target;
    if (console) {
      console.log('Changing ' + target.id + ' from: ' + target.defaultValue + ' to: ' + target.value);
    }
    var change = {};
    change[target.name] = target.value;
    this.model.set(change);
  },

  saveWine: function() {
    this.model.set( {
      name: $('#name').val(),
      grapes: $('#grapes').val(),
      country: $('#country').val(),
      region: $('#region').val(),
      year: $('#year').val(),
      description: $('#description').val()
    });

    if ($('#description').val().length === 0) {
      this.model.set({ description: 'none' });
    }

    if (this.model.isNew()) {
      var self = this;
      app.wineList.create(this.model, {
        success: function() {
          // This will just change the url, the third parameter
          // says whether or not call the route function
          app.navigate('wines/'+self.model.id, false);
        }
      });
    } else {
      this.model.save();
    }
    return false;
  },

  deleteWine: function() {
    if (confirm('Are you sure want to delete this wine?')) {
      this.model.destroy({
        success: function() {
          //app.navigate('', false);
          if (app.wineView) {
            app.wineView.close();
          }
        }
      });
    }
    return false;
  },

  close: function() {
    this.$el.unbind();
    this.$el.empty();
  }
});

window.HeaderView = Backbone.View.extend({
  template:_.template($('#tpl-header').html()),

  render: function() {
    this.$el.html(this.template());
    return this;
  },

  events: {
    'click .new': 'newWine'
  },

  newWine: function() {
    app.navigate('wines/new', true);
    return false;
  }
});

// Router
var AppRouter = Backbone.Router.extend({
  routes:{
    ""          : "list",
    "wines/new" : "newWine",
    "wines/:id" : "wineDetails"
  },

  initialize: function() {
    $('#header').html(new HeaderView().render().el);
  },

  list:function () {
    this.wineList = new WineCollection();

    var self = this;
    this.wineList.fetch({
      reset: true,
      success: function() {
        self.wineListView = new WineListView({ model: self.wineList });
        $('#sidebar').html(self.wineListView.render().el);
        if (self.requestedId) {
          self.wineDetails(self.requestedId);
        }
      }
    });
  },

  newWine: function() {
    // Destroy the previous wineview element if it exists
    if (app.wineView) {
      app.wineView.close();
    }

    app.wineView = new WineView({ model: new Wine() });
    $('#content').html(app.wineView.render().el);
  },

  wineDetails:function (id) {
    if (this.wineList) {
      this.wine = this.wineList.get(id);
      if (this.wineView) {
        this.wineView.close();
      }
      this.wineView = new WineView({ model:this.wine });
      $('#content').html(this.wineView.render().el);
    } else {
      this.requestedId = id;
      this.list();
    }
  }
});

var app = new AppRouter();
Backbone.history.start();
