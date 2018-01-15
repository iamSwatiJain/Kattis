<?php

//$processedCases = 0;
//$firstSet = true;
//while(fscanf(STDIN, "%d", $rows) === 1 && $rows > 0 && $rows <= 200){
//  if ($processedCases > 500) {
//    break;
//  }
  
//  if (!$firstSet) {
//    fprintf(STDOUT, "\n");
//  } else {
//    $firstSet = false;
//  }

//  $lastnames = [];
  
//  for($i = 0; $i < $rows; $i++) {    
//    $lastnames[$i] = trim(fgets(STDIN));
//  }
  
//  if (count ($lastnames) > 0) {
//    uasort($lastnames, function($name1, $name2) {
      //$arr = [
      //  $name1[0].$name1[1],
      //  $name2[0].$name2[1]
      //];
      
      //sort($arr, SORT_STRING);
      
      //return $arr[0] == $name1[0] ? -1 : 1;
      
//      if($name1[0] !== $name2[0]) {
//        return $name1[0] < $name2[0] ? -1 : 1; 
//      } else {
//        return $name1[1] < $name2[1] ? -1 : 1;
//      }
//    });
//  }
  
//  foreach ($lastnames as $lastname) {
//    fprintf(STDOUT, "%s\n", $lastname);
//  }
    
//  $processedCases++;
//}

$firstSet = true;

while(fscanf(STDIN, "%d", $rows) === 1 && $rows > 0) {
  if ($firstSet) {
    $firstSet = false;
  } else {
    fprintf(STDOUT, "\n");
  }
  
  $names = [];
  for($i = 0; $i < $rows; $i++) {
    $names[$i] = [$i, trim(fgets(STDIN))];
  }
  
  usort($names, function($name1, $name2) {
    $result = strncmp($name1[1], $name2[1], 2);
    return $result === 0 ? $name1[0] - $name2[0] : $result;
  });
  
  foreach($names as $name) {
    fprintf(STDOUT, "%s\n", $name[1]);
  }
}