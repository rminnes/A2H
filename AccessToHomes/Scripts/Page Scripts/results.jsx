
var Form = React.createClass(
{
getInitialState: function() {
    return {postCode:this.props.postcode, distance: this.props.distance };
  },
 handlePostcodeChange: function(e) {
    this.setState({postCode: e.target.value});
  },
 handleDistanceChange: function(e) {
    this.setState({distance: e.target.value});
  },
    getLatLng: function(postcode){



    },
  handleSubmit: function(e) {
    e.preventDefault();
        var pc = this.state.postCode.trim();
        var dt = this.state.distance;

        var xhr = new XMLHttpRequest();
        xhr.open('get', '/api/listingapi/getlatlng?location=' +  pc , true);
        xhr.onload = function() {
            var ltlng = JSON.parse(xhr.responseText);
            this.props.onSearchClick({coords:ltlng, distance:dt});
          return ltlng;
        }.bind(this);
        xhr.send();

  },
render(){
    return(
                <div className="col-md-3 p0 padding-top-40">
                    <div className="blog-asside-right pr0">
                        <div className="panel panel-default sidebar-menu wow fadeInRight animated">
                            <div className="panel-heading">
                                <h3 className="panel-title">Smart search</h3>
                            </div>
                            <div className="panel-body search-widget">
        <fieldset>
            <div className="row">
                <div className="col-xs-12">
                    <input type="text" className="form-control" placeholder="Key word" value={this.state.postCode} onChange={this.handlePostcodeChange} />
                </div>
            </div>
        </fieldset>
        <fieldset>
            <div className="row">
                <div className="col-xs-12">

                    <select id="basic" className="selectpicker show-tick form-control" value={this.state.distance} onChange={this.handleDistanceChange}>
                <option value="">Within....</option>
                <option value="3000">3km</option>
                <option value="5000">5km</option>
                <option value="10000">10km</option>
                <option value="25000">25km</option>
                    </select>
                </div>
            </div>
        </fieldset>
        <fieldset>
            <div className="row">
                <div className="col-xs-12">
                    <input className="button btn largesearch-btn" value="Search" type="submit" onClick={this.handleSubmit} />
                </div>
            </div>
       </fieldset>
                                  </div>
                        </div>


                    </div>
                </div>
    );
}

});

const Listing = (props) =>
{
    return(
        <div className="col-sm-6 col-md-4 p0">
            <div className="box-two proerty-item">
                <div className="item-thumb">
                    <a href={"/listing/view/" + props.Id}><img src={props.FirstImage} /></a>
                </div>

                <div className="item-entry overflow">
                    <h5><a href={"/listing/view/" + props.Id}>{props.Title}</a></h5>
                    <div className="dot-hr"></div>
                    <span className="pull-left">{props.Address}</span>
                    <span className="proerty-price pull-right">£{props.Price} pcm</span>
                    <p >{props.ShortDescription}</p>
                    <div className="property-icon">
                        <img src="/assets/img/icon/bed.png" />(5)|
                        <img src="/assets/img/icon/shawer.png" />(2)|
                        <img src="/assets/img/icon/cars.png" />(1)
                    </div>
                </div>
            </div>
        </div>
    );
}

const Listings = (props) =>
{

return (
    <div className="col-md-9  pr0 padding-top-40 properties-page">
        <div className="col-md-12 clear">
          <div id="list-type" className="proerty-th-list">
              {props.data.map(listing => <Listing key={listing.Id} {...listing} />)}
          </div>
        </div>
    </div>
    );


    }

    var App = React.createClass({
    searchClick: function(search) {
    this.setState({ data: [], count: 0, coords: search.coords, distance: search.distance, lastCount:-1});
    this.loadListingsFromServer();
    },
    loadListingsFromServer: function() {
    if (this.state.coords =='' )
    this.state.coords='55.8585849, -4.245605';

    if (this.state.distance==0)
    this.state.distance = 10000;


    var coordArr = this.state.coords.split(',');


    if(this.state.lastCount != this.state.count)
    {
    this.state.lastCount = this.state.count
    this.getListingData( '/api/listingapi/getlistings?count=' + this.state.count + '&take=' +  this.state.take + '&lat=' + coordArr[0] + '&lng=' + coordArr[1] + '&distance=' + this.state.distance);
    }
    },
    getListingData: function(query)
    {
    var xhr = new XMLHttpRequest();
    xhr.open('get', query, true);
    xhr.onload = function() {
    var newData = JSON.parse(xhr.responseText);

    if (this.state.count > 0)
    {
    this.ListingCount = this.ListingCount +newData.length;
    this.setState(prevState => ({ data: prevState.data.concat(newData) , count : prevState.count + newData.length }));
    }
    else
    {
    this.ListingCount = this.ListingCount +newData.length;
    this.setState(prevState => ({ data:newData , count : prevState.count + newData.length }) );
    }


    }.bind(this);
    xhr.send();
    },

    getInitialState: function() {
    //this.ListingCount = 0;

    return { data: [], take :3, count: 0, coords: '', distance: 0, lastCount:-1};
    },
    onScroll : function() {
    if ((window.innerHeight + window.scrollY) >= (document.body.offsetHeight - 10)) {
    this.loadListingsFromServer();
    }
    },

    componentDidMount: function() {

    this.state.coords='55.8642, -4.2518';
    this.state.distance=this.props.Distance;
    this.loadListingsFromServer();

    window.addEventListener('scroll',this.onScroll, false);

    },
    render(){
    return(
            <div className="row">
                <Form onSearchClick={this.searchClick} postcode={this.props.Postcode} distance={this.props.Distance} />
			    <Listings data={this.state.data} />
            </div>
    );
    }
    });
