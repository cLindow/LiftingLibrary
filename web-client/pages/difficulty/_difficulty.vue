<template>
  <div>
    <div>
      <b-card v-if="difficulty">
        <b-card-title>
          <h3>{{difficulty.name}}</h3>
        </b-card-title>
        <b-card-text>
          <div class="text-body">{{difficulty.description}}</div>
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
  name: "difficulty",
  components: {ExerciseList},
  data: () => ({
    difficulty: null,
    exercises: [],
  }),
  computed: mapGetters("exercises", ["difficultyById"]),
  async fetch()
  {
    const difficultyId = this.$route.params.difficulty
    this.difficulty = this.difficultyById(difficultyId)
    this.exercises = await this.$axios.$get(`/api/difficulties/${difficultyId}/exercises`)
  },
  head() {
    if (this.difficulty === null) return {}
    return {
      title: this.difficulty.name,
      meta: [
        { hid: "description", name: "description", content: this.difficulty.description}
      ]
    }
  }
}
</script>

<style scoped>

</style>
