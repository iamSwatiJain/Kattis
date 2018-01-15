<?php

$keepReading = true;
while($keepReading) {
  $line = trim(fgets(STDIN));
  
  if(!feof(STDIN)) {
    fprintf(STDOUT, "%s\n", preg_match('/problem/i', $line) ? 'yes' : 'no');
  } else {
    $keepReading = false;
  }  
}