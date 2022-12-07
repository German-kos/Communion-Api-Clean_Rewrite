# Aggregates

## Aggregate Rules

- Reference other aggregates by ID
- Changes are committed & rolled back as a whole
- Changes to an aggregate are done via the root

## Aggregate Modeling Steps

- Define each of the entities as an aggregate
- Merge aggregates to enforce invariance
- Merge aggregates that cannot tolerate inconsistency

## Good Questions To Ask Yourself

- ***Does the entity make sense without the other?***
  - if not then it's probably a local entity and not an aggregate root.
- ***Will it need to be looked up?***
  - if yes then it's probably an aggregate root.
- **Will it be reference by other aggregates?**
  - if yes then it's probably an aggregate root.
