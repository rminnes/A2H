
var Form = React.createClass(
{
getInitialState: function() {

    return {postCode:'', distance: 1000 };
  },
 handlePostcodeChange: function(e) {
    this.setState({postCode: e.target.value});
  },
 handleDistanceChange: function(e) {
    this.setState({distance: e.target.value});

  },
  handleSubmit: function(e) {
    e.preventDefault();
        var pc = this.state.postCode.trim();
        var dt = this.state.distance;

        this.props.onSearchClick({pCode:pc, Dist:dt});
  },
render(){
    return(

        <div className="row">
            <label>Postcode <input type="text" name="postcode" className="form-control" value={this.postCode} onChange={this.handlePostcodeChange} /></label>
            <br />
            <label>Distance</label>
            <select className="form-control" onChange={this.handleDistanceChange}>
                <option value="">Within....</option>
                <option value="3000">3km</option>
                <option value="5000">5km</option>
                <option value="10000">10km</option>
                <option value="25000">25km</option>
            </select>

            <input type="submit" value="Search" className="btn btn-default" onClick={this.handleSubmit} />
        </div>

    );
}

});

const Listing = (props) =>
{
    return(
        <div className="row">
            <div className="col-md-3 dv-listing">
                <a href={"/listing/view/" + props.Id}>
                    <img className="rounded mb-3 mb-md-0" height="200" width="200" src={props.FirstImage} alt="" />

                </a>
            </div>
            <div className={"col-md-9"}>
                <div className="row">
                    <div className="col-md-9"><a href={"/listing/view/" + props.Id}>{props.Title}</a></div>
                    <div className="col-md-3">£{props.Price} pcm</div>
                </div>

                <p>{props.ShortDescription}</p>
            </div>
        </div>

    );
}

const Listings = (props) =>
{

return (
  <div>
      {props.data.map(listing => <Listing key={listing.Id} {...listing} />)}
  </div>
);


}

var App = React.createClass({
    searchClick: function(test) {
       this.loadListingsFromServer(0,2);
  },
    loadListingsFromServer: function(cnt, tk) {

        var xhr = new XMLHttpRequest();
        xhr.open('get', '/api/listingapi/getlistings?count=' + cnt + '&take=' +  tk, true);
        xhr.onload = function() {
          var data = JSON.parse(xhr.responseText);
          this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },

getInitialState: function() {
    return { data: []};
  },

  componentDidMount: function() {
    window.setInterval(this.loadListingsFromServer(0,3), this.props.pollInterval);
  },
	render(){
		return(
            <div>
                <Form onSearchClick={this.searchClick} />
			    <Listings data={this.state.data} />
            </div>
		);
	}
});



