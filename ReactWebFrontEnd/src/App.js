import React, { Component } from 'react';
import './App.css';

class App extends Component {

  constructor(props) {
    super(props);
    console.log("App-komponentti: konstruktori (rakentaja).");

    this.state = null;
  }

  componentDidMount() {

    console.log("App-komponentti: componentDidMount-metodissa.");
    this.setState({ title: "Väliaikainen otsikko"} );

    fetch('https://localhost:44357/api/customers')
      .then(response => response.json())
      .then(json => {
        console.log(json);

        console.log("App-komponentti: aloitetaan setState()-kutsu.");
        this.setState(json);
        console.log("App-komponentti: setState()-metodia kutsuttu.");

      });

    console.log("App-komponentti: Fetch-kutsu tehty.");
  }

  render() {

    console.log("App-komponentti: render-metodissa.");

    let otsikko = "";
    if (this.state != null) {
      otsikko = this.state.title;
    }

    return (<div>
      <h1>App-komponentti</h1>
      <p>{otsikko}</p>
    </div>
    );
  }
}

export default App;
