<template>
<div>
  <h1>Hello!</h1>
  <h2>{{msg}}</h2>
  <router-link to="/">Route local to first page</router-link>
</div>
</template>

<script>
export default {
  name: 'HelloWorld1',
  data () {
    return {
      msg: 'I\'m the second page!'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
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
