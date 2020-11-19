<template>
  <div>
    <div>

    </div>
    <div v-if="exercises">
      <div v-for="e in exercises">
        {{e.name}}
        <div>
          <video
            width="400"
            controls
            :src="`http://localhost:5000/api/videos/${e.video}`"></video>
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
  },
}

</script>
