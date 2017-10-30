

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
getInitialState: function() {
    return {data: []};
  },

  componentWillMount: function() {
    var xhr = new XMLHttpRequest();
    xhr.open('get', '/api/listingapi/getlistings?count=0&take=3', true);
    xhr.onload = function() {
      var data = JSON.parse(xhr.responseText);
      this.setState({ data: data });
    }.bind(this);
    xhr.send();
  },
	render(){
		return(
			<Listings data={this.state.data} />
		);
	}
});

React.render(<App />, document.getElementById('content'));