<template>
  <b-card>
    <h3>Exercsises</h3>
    <b-form-input placeholder="search" type="search" v-model="filter"
                  class="mb-2"></b-form-input>
    <div v-if="filteredExercises.length > 0" v-for="e in filteredExercises">
      <h4>{{e.name}}</h4>
      <p>{{e.description}}</p>
    </div>
  </b-card>
</template>

<script>
export default {
name: "exercise-list",
  props: {
  exercises: {
    required: true,
    type: Array,
  },
  },
  data: () => ({
    filter: "",
  }),
  computed: {
    filteredExercises() {
      if(!this.filter) return this.exercises;

      const normalize = this.filter.trim().toLowerCase()
      return this.exercises.filter(e => e.name.toLowerCase().includes(normalize)
        || e.description.toLowerCase().includes(normalize));
    }
  }
}
</script>

<style scoped>

</style>
