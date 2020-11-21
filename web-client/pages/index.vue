<template>
  <div>
    <div v-if="exercises">
      <div v-for="e in exercises">
        <b-btn :to="`/exercises/${e.id}`">{{e.name}}</b-btn>
        <div>
      </div>
    </div>
  </div>
  </div>
</template>
<script>
import {mapState} from "vuex";
export default {
  computed: mapState("exercises", ["exercises"])
}

</script>
