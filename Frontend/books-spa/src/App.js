import React, { Component } from 'react';
import axios from "axios";
import './App.css';

class App extends Component {
  constructor() {
    super();
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.state = {
      table: [],
      title: undefined,
      author: undefined,
      }
    }

    handleChange(event) {
      console.log(event.target.name, event.target.value);
      this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event){ 
      event.preventDefault();
      const book = { 
        title: this.state.title,
        author: this.state.author
      }
      fetch("https://localhost:44307/index/", {
        method: "POST",
        body: JSON.stringify(book),
        mode: "cors",
        headers: new Headers({
          "Content-Type": "application/json"
        })
      });
      setTimeout(this.componentWillMount, 500)
     };

     removeBook(id) {
       console.log(id)
      axios.get(
        "https://localhost:44307/index/" + id
      );
      setTimeout(this.componentWillMount, 500);
    }

    componentWillMount = () => 
    fetch("https://localhost:44307/index/", {
      mode: "cors"
    })
      .then(res => res.json())
      .then(table => this.setState({ table }));

  render() {
   const renderedTable = (
  <div>
    
    {console.log(this.state.table)}
    <table className="Table">
    <tr>
      <th>
        Author
      </th>
      <th>
        Title
      </th>
      <th>
        Delete
      </th>
    </tr>
    {this.state.table.map(element => (
     <tr>
     <td>
       {element.author}
     </td>
     <td>
     {element.title}
     </td>
     <td>
     <button onClick={() => this.removeBook(element.id)}> x </button>
     </td>
   </tr>
    ))}
    <tr>
  </tr>
  </table>
  <form onSubmit={this.handleSubmit}>
<input type="text" onChange={this.handleChange} name="author" required></input>
<input type="text" onChange={this.handleChange} name="title" required></input>
<input type="submit" value="Add" />
  </form>
  </div>
   )

    return (
      <div>{renderedTable}</div>
    )
  }
}

export default App;
