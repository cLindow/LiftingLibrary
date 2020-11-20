<template>
  <div>
  <div>
    Exercise: {{$route.params.exercise}}
  </div>

  <div v-if="submissions">
    <div v-for="s in submissions">
      {{s.description}}
      <div>
        <video
          width="400"
          controls
          :src="`http://localhost:5000/api/videos/${s.video}`"></video>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
import {mapState} from "vuex";
export default {
  computed: mapState("submissions", ["submissions"]),
  async fetch()
  {
    const exerciseId = this.$route.params.exercise
    await this.$store.dispatch("submissions/fetchSubmissionsForExercise", {exerciseId}, {root: true})
  }
}
</script>

<style scoped>

</style>
