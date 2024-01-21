#pragma once

#include "CoreMinimal.h"
#include "EditorSubsystem.h"
#include "CSEditorSubsystem.generated.h"

UCLASS(Blueprintable, BlueprintType, Abstract)
class UCSEditorSubsystem : public UEditorSubsystem
{
	GENERATED_BODY()

	// USubsystem Begin
	
	virtual void Initialize(FSubsystemCollectionBase& Collection) override
	{
		Super::Initialize(Collection);
		K2_Initialize();
	}
  
	virtual void Deinitialize() override
	{
		Super::Deinitialize();
		K2_Deinitialize();
	}
  
	virtual bool ShouldCreateSubsystem(UObject* Outer) const override
	{
		if (!Super::ShouldCreateSubsystem(Outer))
		{
			return false;
		}
  
		return K2_ShouldCreateSubsystem();
	}

	// End

	protected:

	UFUNCTION(BlueprintImplementableEvent, meta = (ScriptName = "ShouldCreateSubsystem"), Category = "Managed Subsystems")
	bool K2_ShouldCreateSubsystem() const;
  
	UFUNCTION(BlueprintImplementableEvent, meta = (ScriptName = "Initialize"), Category = "Managed Subsystems")
	void K2_Initialize();
  
	UFUNCTION(BlueprintImplementableEvent, meta = (ScriptName = "Deinitialize"), Category = "Managed Subsystems")
	void K2_Deinitialize();
	
};
