import React, { Component } from 'react';
import './App.css';

class App extends Component {

  constructor(props) {
    super(props);
    console.log("App-komponentti: konstruktori (rakentaja).");

    this.state = { asiakkaat: [] };
  }

  componentDidMount() {

    // console.log("App-komponentti: componentDidMount-metodissa.");
    // this.setState({ title: "Väliaikainen otsikko"} );

    fetch('https://localhost:44357/api/customers')
      .then(response => response.json())
      .then(json => {
        console.log(json);

        console.log("App-komponentti: aloitetaan setState()-kutsu.");
        this.setState({ asiakkaat: json });
        console.log("App-komponentti: setState()-metodia kutsuttu.");

      });

    console.log("App-komponentti: Fetch-kutsu tehty.");
  }

  render() {

    console.log("App-komponentti: render-metodissa.");

    let viesti = "";
    let taulukko = [];
    if (this.state.asiakkaat.length > 0) {

      for (let index = 0; index < this.state.asiakkaat.length; index++) {
        const element = this.state.asiakkaat[index];
        taulukko.push(<tr>
          <td>{element.customerId}</td>
          <td>{element.companyName}</td>
          <td>{element.city}</td>
        </tr>);
      }
      
    }
    else {
      viesti = "Ladataan tietoja..."
    }

    return (<div>
      <h1>App-komponentti</h1>
      <p>{viesti}</p>
      <table>
      {taulukko}
      </table>
    </div>
    );
  }
}

export default App;
