<template>
<div>
  <h1>Hello I'm the first page!!</h1>
  <h2>{{myData}}</h2>
  <button @click="myData = 'Hi! I\'m local data'">Click me for local data</button>
  <button @click="getRemote">Click me for remote  data</button>
  <router-link to="/another">Route local to second page</router-link>
</div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'HelloWorld',
  data() {
    return {
      myData: ''
    }
  },
  methods: {
    getRemote: function() {
      let self = this
      // put baseurl into a global module with your ajax library and will be dynamic
      axios
        .get('http://localhost:5000/serverData')
        .then(function(response) {
          self.myData = response.data.Text
          console.log(response)
        })
        .catch(function(error) {
          // handle error
          self.myData = error
        })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
