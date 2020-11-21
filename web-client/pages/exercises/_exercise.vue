<template>
  <div>
   <div>
    <b-card>
      <b-card-title>
        <h3>{{exercise.name}}</h3>
      </b-card-title>
      <b-card-text>
        <div class="text-body">{{exercise.name}}</div>
        <div class="text-body">{{exercise.description}}</div>
        <div class="text-body">{{exercise.difficulty}}</div>
        <div v-for="rd in relatedData" v-if="rd.data.length > 0">
          {{rd.title}}
          <b-button-group size="sm">
            <b-button v-for="d in rd.data" class="px-2 m-1" :to="rd.routeFactory(d)">{{d.name}}</b-button>
          </b-button-group>
        </div>
      <div v-if="submissions">
        <b-card>
          <h3>Submissions</h3>
        <div v-for="s in submissions">
            <h4>{{s.description}}</h4>
              <video
                controls
                :src="`http://localhost:5000/api/videos/${s.video}`">
              </video>
        </div>
        </b-card>
      </div>
      </b-card-text>
    </b-card>
   </div>
  </div>



</template>

<script>
import {mapGetters,mapState} from "vuex";
export default {
  computed: {
    ...mapState("submissions", ["submissions"]),
    ...mapState("exercises", ["categories", "exercises"]),
    ...mapGetters("exercises", ["exerciseById"]),
    exercise() {
      const exerciseId = this.$route.params.exercise;
      const exercise = this.exerciseById(exerciseId)
      console.log(exercise);
      return exercise;
    },
    relatedData() {
      return [
        {
          title: "Categories",
          data: this.categories.filter(x => this.exercise.categories.indexOf(x.id) >= 0),
          idFactory: c => `category-${c.id}`,
          routeFactory: c => `/`,
        },
        {
          title: "Prerequisites",
          data: this.exercises.filter(x => this.exercise.prerequisites.indexOf(x.id) >= 0),
          idFactory: e => `exercises-${e.id}`,
          routeFactory: e => `/exercises/${e.id}`
        },
        {
          title: "Progressions",
          data: this.exercises.filter(x => this.exercise.progressions.indexOf(x.id) >= 0),
          idFactory: e => `exercises-${e.id}`,
          routeFactory: e => `/exercises/${e.id}`
        },
      ]
    }
},
  async fetch()
  {
    const exerciseId = this.$route.params.exercise
    await this.$store.dispatch("submissions/fetchSubmissionsForExercise", {exerciseId}, {root: true})
  },
  head() {
    return {
      title: this.exercise.name,
      meta: [
        { hid: "description", name: "description", content: this.exercise.description}

      ]
    }
  }
}
</script>

<style scoped>

</style>
