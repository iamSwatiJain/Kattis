<?php
// Open file for reading
//$fh = fopen("cups-01.in", "r");

// Scan the number of cups
fscanf(STDIN, "%d", $rows);


$cups = [];
for($i = 0; $i < $rows; $i++) {
  if (fscanf(STDIN, "%s%s", $arg1, $arg2) === 2) {
    if (is_numeric($arg1)) {
      $cup = [
        'color' => $arg2,
        'radius' => $arg1 / 2
      ];
    } else {
    $cup = [
        'color' => $arg1,
        'radius' => (int)$arg2
      ];
    }
    $cups[$i] = $cup;
  }
}

if (count ($cups) > 0) {
  usort($cups, function($cup1, $cup2) {
    return $cup1['radius'] > $cup2['radius'] ? 1 : -1;
  });
}

foreach ($cups as $v){
  fprintf(STDOUT, "%s\n", $v['color']);
}