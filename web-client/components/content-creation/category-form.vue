<template>
<b-card>
  <b-card-title>Create Category</b-card-title>
  <b-card-text>
    <b-row class="my-1">
      <b-col sm="3">
        <label :for="name">Category Name</label>
      </b-col>
      <b-col sm="8">
        <b-form-input v-model="form.name" id="name" placeholder="Category Name"></b-form-input>
      </b-col>
    </b-row>
    <b-row class="my-1">
      <b-col sm="3">
        <label :for="name">Category Description</label>
      </b-col>
      <b-col sm="8">
        <b-form-input v-model="form.description" id="name" placeholder="Category Description"></b-form-input>
      </b-col>
    </b-row>
  </b-card-text>
  <b-card-footer>
    <b-btn @click="save">Save</b-btn>
  </b-card-footer>
</b-card>
</template>

<script>
const initState = () => ({
  form: {
    name: "",
    description: "",
  },
})
export default {
  name: "category-form",
  data: initState,
  methods: {
    save() {
      this.$axios.post("/api/categories", this.form)
    }
  }
}
</script>

<style scoped>

</style>
