<template>
  <div>
    <div>
      <b-card v-if="category">
        <b-card-title>
          <h3>{{category.name}}</h3>
        </b-card-title>
        <b-card-text>
          <div v-if="exercises">
            <exercise-list :exercises="exercises" />
          </div>
        </b-card-text>
      </b-card>
    </div>
  </div>



</template>

<script>
import {mapGetters} from "vuex";
import ExerciseList from "@/components/exercise-list";
export default {
  name: "category",
  components: {ExerciseList},
  data: () => ({
    category: null,
    exercises: [],
  }),
  computed: mapGetters("exercises", ["categoryById"]),
  async fetch()
  {
    const categoryId = this.$route.params.category
    this.category = this.categoryById(categoryId)
    this.exercises = await this.$axios.$get(`/api/categories/${categoryId}/exercises`)
  },
  head() {
    if (this.category === null) return {}
    return {
      title: this.category.name,
      meta: [
        { hid: "description", name: "description", content: this.category.description}
      ]
    }
  }
}
</script>

<style scoped>

</style>
