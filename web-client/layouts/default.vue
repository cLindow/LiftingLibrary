<template>
  <div class="px-5">
  <div>
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <b-navbar-brand href="#">Exercise Library</b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item href="#">Home</b-nav-item>
          <b-nav-item href="#">Videos</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-nav-item @click="toggleActive">Upload</b-nav-item>
          </b-nav-form>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
    <video-upload/>
  <div>
    <Nuxt />
  </div>
  </div>
</template>

<script>
import {mapMutations} from "vuex";
import VideoUpload from "../components/video-upload"

export default {
  methods: mapMutations("video-upload", ['toggleActive']),
  components: {
  VideoUpload
  }
}
</script>
