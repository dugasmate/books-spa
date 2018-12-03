import React, { Component } from 'react';
import './App.css';

class App extends Component {
  constructor() {
    super();
    this.state = {
      table: []
      }
    }
    
    componentWillMount = () => 
    fetch("https://localhost:44307/index/", {
      mode: "cors"
    })
      .then(res => res.json())
      .then(table => this.setState({ table }));

  render() {
    return (
      <div className="App">
      <table className="Table">
      <tr>
        <th>
          Title
        </th>
        <th>
          Author
        </th>
      </tr>
      {this.state.table.map(element => (
       <tr>
       <td>
         {element.title}
       </td>
       <td>
       {element.author}
       </td>
     </tr>
      ))}
      </table>
      <form>
        
      </form>
      </div>);
  }
}

export default App;
