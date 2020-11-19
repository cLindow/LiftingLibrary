<template>
  <div>
    <div v-if="exercises">
      <div v-for="e in exercises">
        {{e.name}}
        <div>
      </div>
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
  </div>
</template>
<script>
import {mapState} from "vuex";
export default {
  computed: {
    ...mapState("exercises", ["exercises"]),
    ...mapState("submissions", ["submissions"]),
  },
}

</script>
